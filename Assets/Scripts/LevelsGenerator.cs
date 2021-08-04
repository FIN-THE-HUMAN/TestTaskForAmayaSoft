using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;

public class LevelsGenerator : MonoBehaviour
{ 
    [SerializeField]
    private Cell _cellPrefab;
    [SerializeField]
    private float _cellBounceDuration;
    [SerializeField]
    private Color[] _buttonColors;
    [SerializeField]
    private AnswerChecker _answerChecker;
    [SerializeField]
    private TaskPresenter _taskPresenter;
    [Space]
    [SerializeField]
    private GridLayoutGroup[] _grids;
    [SerializeField]
    private LevelOptions[] _levels;
    [SerializeField]
    private CellsPicturesAndNamesSet[] CellsPicturesSets;
    [Space]
    [SerializeField]
    private UnityEvent LevelsEnded;

    private int tempLevel = 1;
    private PictureAndNamePair previousAnswer;

    void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel() 
    {
        if (tempLevel > _grids.Length)
        {
            LevelsEnded.Invoke();
            var childrenButtons = _grids[tempLevel - 2].GetComponentsInChildren<Button>();
            foreach (var b in childrenButtons) b.enabled = false;
            return;
        }

        if(tempLevel > 1) ClearLevel(tempLevel - 1);

        _grids[tempLevel - 1].gameObject.SetActive(true);

        if (CellsPicturesSets.Length == 0) throw new System.IndexOutOfRangeException("There are no CellsPicturesSets");
        var randomSet = CellsPicturesSets[Random.Range(0, CellsPicturesSets.Length)];

        if (randomSet.PictureAndNamePairs.Length == 0) throw new System.IndexOutOfRangeException("current CellsPicturesSets is empty");

        int gridHeight = _levels[tempLevel - 1].gridHeight;
        int gridWidth = _levels[tempLevel - 1].gridWidth;
        int gridSize = gridHeight * gridWidth;

        var shuffledColors = _buttonColors.Shuffle();
        var shuffledPictureAndNamePairs = randomSet.PictureAndNamePairs.Shuffle();
        if (tempLevel > 1) shuffledPictureAndNamePairs = shuffledPictureAndNamePairs.Remove(previousAnswer);
        var answer = shuffledPictureAndNamePairs[Random.Range(0, gridSize)];
        _answerChecker.SetAnswer(answer.Picture.sprite);
        _taskPresenter.SetAnswer(answer.Name);
        previousAnswer = answer;

        for (int i = 0; i < gridSize; i++)
        {
            var cell = Instantiate(_cellPrefab);
            
            cell.GetComponent<Image>().color = shuffledColors[i % (gridSize)];

            var randomPictureAndNamePair = shuffledPictureAndNamePairs[i];
            cell.Picture.sprite = randomPictureAndNamePair.Picture.sprite;
            cell.Picture.transform.rotation = randomPictureAndNamePair.Picture.transform.rotation;
            cell.Picture.transform.localScale = randomPictureAndNamePair.Picture.transform.localScale;
            cell.transform.SetParent(_grids[tempLevel - 1].gameObject.transform);
            cell.Button.onClick.AddListener(() => StartCoroutine(_answerChecker.CheckAnswer(cell)));

            cell.transform.position = new Vector3(cell.transform.position.x, cell.transform.position.y, 0);
            cell.transform.DOScale(new Vector3(0.1f, 0.1f, 0.1f), 0.01f);
            cell.transform.DOScale(new Vector3(1f, 1f, 1f), _cellBounceDuration);
            
        }
        tempLevel++;
    }

    public void ClearLevel(int level)
    {
        var children = _grids[level - 1].GetComponentsInChildren<Button>();
        for (int i = 0; i < children.Length; i++) Destroy(children[i].gameObject);
        _grids[level - 1].gameObject.SetActive(false);
    }

    public void ResetLevels()
    {
        ClearLevel(tempLevel - 1);
        tempLevel = 1;
        GenerateLevel();
    }
}

[System.Serializable]
public class CellsPicturesAndNamesSet
{
    public PictureAndNamePair[] PictureAndNamePairs;
}

[System.Serializable]
public class PictureAndNamePair
{
    public PictureAndNamePair(string name, Image picture)
    {
        Name = name;
        Picture = picture;
    }

    public string Name;
    public Image Picture;
}

[System.Serializable]
public class LevelOptions
{
    public int gridHeight;
    public int gridWidth;
}

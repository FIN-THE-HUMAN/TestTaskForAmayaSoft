
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LevelsGenerator : MonoBehaviour
{
    [SerializeField]
    private Cell _cellPrefab;
    [SerializeField]
    private GridLayoutGroup _grid;
    [SerializeField]
    private Color[] _buttonColors;
    [SerializeField]
    private AnswerChecker _answerChecker;
    [SerializeField]
    private TaskInitializer _taskInitializer;

    [Space]
    public LevelOptions[] Levels;
    [Space]
    public TaskInitializer TaskInitializer;
    public CellsPicturesAndNamesSet[] CellsPicturesSets;

    private int tempLevel = 1;

    void Awake()
    {
        GenerateLevel();
    }

    public void GenerateLevel() 
    {
        if (tempLevel > Levels.Length) return;
        tempLevel++;

        if (CellsPicturesSets.Length == 0) throw new System.IndexOutOfRangeException("There are no CellsPicturesSets");
        var randomSet = CellsPicturesSets[Random.Range(0, CellsPicturesSets.Length)];

        if (randomSet.PictureAndNamePairs.Length == 0) throw new System.IndexOutOfRangeException("current CellsPicturesSets is empty");

        int gridHeight = Levels[tempLevel - 1].gridHeight;
        int gridWidth = Levels[tempLevel - 1].gridWidth;
        int gridSize = gridHeight * gridWidth;

        var shuffledColors = _buttonColors.Shuffle();
        var shuffledPictureAndNamePairs = randomSet.PictureAndNamePairs.Shuffle();
        var answer = shuffledPictureAndNamePairs[UnityEngine.Random.Range(0, gridSize)];
        _answerChecker.SetAnswer(answer.Picture.sprite);
        _taskInitializer.SetAnswer(answer.Name);

        for (int i = 0; i < gridSize; i++)
        {
            var cell = Instantiate(_cellPrefab);
            
            cell.GetComponent<Image>().color = shuffledColors[i % (gridSize)];

            var randomPictureAndNamePair = shuffledPictureAndNamePairs[i];
            cell.Picture.sprite = randomPictureAndNamePair.Picture.sprite;
            cell.Picture.transform.rotation = randomPictureAndNamePair.Picture.transform.rotation;
            cell.Picture.transform.localScale = randomPictureAndNamePair.Picture.transform.localScale;
            cell.transform.SetParent(_grid.gameObject.transform);
            cell.Button.onClick.AddListener(() => _answerChecker.CheckAnswer(cell));
        }

        Debug.Log("Level Generated");
    }

    public void ResetLevels()
    {

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

using UnityEngine;
using UnityEngine.Events;

public class AnswerChecker : MonoBehaviour
{
    private Sprite _answerSprite;
    [SerializeField]
    public TaskPresenter _taskPresenter;
    [SerializeField]
    public LevelsGenerator _levelsGenerator;
    [SerializeField]
    private CellEvent _onAnswerAccepted;

    public CellEvent OnAnswerAccepted => _onAnswerAccepted;

    public void CheckAnswer(Cell pressedCell)
    {
        if (pressedCell.Picture.sprite == _answerSprite)
        {
            _onAnswerAccepted.Invoke(pressedCell);
        }
        else
        {
            pressedCell.ReactToWrongAnswer();
        }
    }

    public void SetAnswer(Sprite answerSprite)
    {
        _answerSprite = answerSprite;
    }
}

[System.Serializable]
public class CellEvent : UnityEvent<Cell> { }
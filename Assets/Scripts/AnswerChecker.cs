using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AnswerChecker : MonoBehaviour
{
    private Sprite _answerSprite;
    [SerializeField]
    private TaskPresenter _taskPresenter;
    [SerializeField]
    private LevelsGenerator _levelsGenerator;
    [SerializeField]
    private float _answerWaiting;
    [SerializeField]
    private CellEvent _onAnswerAcceptedStart;
    [SerializeField]
    private CellEvent _onAnswerAcceptedEnd;
    [SerializeField]
    private CellEvent _onAnswerRejected;

    public CellEvent OnAnswerAcceptedStart => _onAnswerAcceptedStart;
    public CellEvent OnAnswerAccepted => _onAnswerAcceptedEnd;
    public CellEvent OnAnswerRejected => _onAnswerRejected;

    public IEnumerator CheckAnswer(Cell pressedCell)
    {
        if (pressedCell.Picture.sprite == _answerSprite)
        {
            _onAnswerAcceptedStart.Invoke(pressedCell);
            yield return new WaitForSeconds(_answerWaiting);
            _onAnswerAcceptedEnd.Invoke(pressedCell);
        }
        else
        {
            OnAnswerRejected.Invoke(pressedCell);
            yield return null;
        }
    }

    public void SetAnswer(Sprite answerSprite)
    {
        _answerSprite = answerSprite;
    }
}

[System.Serializable]
public class CellEvent : UnityEvent<Cell> { }
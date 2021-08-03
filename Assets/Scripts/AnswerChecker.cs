using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    private const string WrongAnswer = "Wrong Answer";
    private const string RightAnswer = "Right Answer";
    private Sprite _answerSprite;

    public TaskInitializer TaskInitializer;
    public LevelsGenerator LevelsGenerator;

    [Space]
    public Text AnswerReactionText;

    public UnityEvent onAnswerAccepted;
    public UnityEvent onAnswerRejected;

    void Start()
    {
        AnswerReactionText.enabled = false;
    }
    public void CheckAnswer(Cell pressedCell)
    {
        AnswerReactionText.enabled = true;

        if (pressedCell.Picture.sprite == _answerSprite)
        {
            AnswerReactionText.text = RightAnswer;
            onAnswerAccepted.Invoke();
        }
        else
        {
            AnswerReactionText.text = WrongAnswer;
            pressedCell.ReactToWrongAnswer();
        }

    }

    public void SetAnswer(Sprite answerSprite)
    {
        _answerSprite = answerSprite;
    }
}

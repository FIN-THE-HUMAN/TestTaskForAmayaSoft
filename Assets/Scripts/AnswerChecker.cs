using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    private const string WrongAnswer = "Wrong Answer";
    private const string RightAnswer = "Right Answer";

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

        if (pressedCell.Picture.sprite == TaskInitializer.RightPicture)
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
}

[Serializable]
public class AnswerCheckEvent : UnityEvent<bool> { }
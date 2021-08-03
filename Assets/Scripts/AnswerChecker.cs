using UnityEngine;
using UnityEngine.UI;

public class AnswerChecker : MonoBehaviour
{
    private const string WrongAnswer = "Wrong Answer";
    private const string RightAnswer = "Right Answer";

    public TaskInitializer TaskInitializer;
    public LevelsGenerator LevelsGenerator;

    [Space]
    public Text AnswerReactionText;

    void Start()
    {
        AnswerReactionText.enabled = false;
    }
    public void CheckAnswer(Image picture)
    {
        if (picture.sprite == TaskInitializer.RightPicture)
        {
            AnswerReactionText.text = RightAnswer;
            LevelsGenerator.GenerateLevel();
        }
        else
        {
            AnswerReactionText.text = WrongAnswer;
        }
    }
}

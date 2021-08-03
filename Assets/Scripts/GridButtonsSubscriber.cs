using UnityEngine;

public class GridButtonsSubscriber : MonoBehaviour
{
    public GridContainer GridContainer;
    public AnswerChecker AnswerChecker;

    void Start()
    {

    }

    public void Subscribe()
    {
        for (int i = 0; i < GridContainer.Cells.Length; i++)
        {
            int buttonPosition = i;
            GridContainer.Cells[buttonPosition].Button.onClick.AddListener(() => AnswerChecker.CheckAnswer(GridContainer.Cells[buttonPosition]));
            // AnswerChecker.onAnswerCkecked.AddListener((a) => GridContainer.Cells[buttonPosition].ReactToAnswer(a));
        }
    }
}

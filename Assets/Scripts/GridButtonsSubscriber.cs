using UnityEngine;

public class GridButtonsSubscriber : MonoBehaviour
{
    public GridContainer GridContainer;
    public AnswerChecker AnswerChecker;

    void Start()
    {
        for(int i = 0; i < GridContainer.Cells.Length; i++)
        {
            int buttonPosition = i;
            GridContainer.Cells[buttonPosition].Button.onClick.AddListener(() => AnswerChecker.CheckAnswer(GridContainer.Cells[buttonPosition].Picture));
        }
    }
}

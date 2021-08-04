using UnityEngine;
using UnityEngine.UI;

public class TaskPresenter : MonoBehaviour
{
    private const string FIND = "Find ";
    private string _answer;
    [SerializeField]
    private Text _taskText;

    void Start()
    {
        _taskText.text = FIND + _answer;
    }

    public void SetAnswer(string answer)
    {
        _answer = answer;
        _taskText.text = FIND + _answer;
    }
}

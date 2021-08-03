using UnityEngine;
using UnityEngine.UI;

public class TaskInitializer : MonoBehaviour
{
    private const string FIND = "Find ";

    public string _answer;
    public Sprite _rightPicture;

    public Sprite RightPicture => _rightPicture;
    public Text TaskText;

    void Start()
    {
        TaskText.text = FIND + _answer;
    }

    public void SetAnswer(string answer)
    {
        _answer = answer;
    }
}

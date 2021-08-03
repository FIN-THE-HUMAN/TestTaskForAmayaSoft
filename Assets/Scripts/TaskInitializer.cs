using UnityEngine;
using UnityEngine.UI;

public class TaskInitializer : MonoBehaviour
{
    private const string Find = "Find ";

    //public int RightAnswerPosition;
    public string Answer;
    public Sprite RightPicture;

    [Space]
    public Text TaskText;

    void Start()
    {
        TaskText.text = Find + Answer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

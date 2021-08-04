using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class Cell : MonoBehaviour
{
    public Button Button;
    public Image Picture;

    public void ReactToWrongAnswer()
    {
        Picture.transform.DOShakePosition(1, 3);
    }

}

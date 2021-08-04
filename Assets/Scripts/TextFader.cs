using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TextFader : MonoBehaviour
{
    [SerializeField]
    private Text _text;
    [SerializeField]
    private float _fadeDuration;

    void Start()
    {
        _text.DOColor(_text.color.ChangeAlpha(1), _fadeDuration);
    }
}

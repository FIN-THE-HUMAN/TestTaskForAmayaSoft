using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    [SerializeField]
    private Image _screenImage;

    [SerializeField]
    private float _duration;

    private void Fade(float alpha, float duration)
    {
        _screenImage.DOColor(_screenImage.color.ChangeAlpha(alpha), duration);
    }

    public void FadeToScreenStop()
    {
        Fade(0.5f, _duration);
    }

    public void FadeToBlackScreen()
    {
        Fade(1f, _duration);
    }

    public void FadeToClearScreen()
    {
        Fade(0f, _duration);
    }

    public void FadeLoadingScreen()
    {
        FadeToBlackScreen();
        FadeToClearScreen();
    }
}

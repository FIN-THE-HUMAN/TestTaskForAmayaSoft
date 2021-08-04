using DG.Tweening;
using UnityEngine;

public class CellShaker : MonoBehaviour
{
    [SerializeField]
    private float _shakeDuration;
    [SerializeField]
    private float _shakeStrenght;
    [SerializeField]
    private AnswerChecker _answerChecker;

    public void ShakeCell(Cell cell)
    {
        cell.transform.DOShakePosition(_shakeDuration, _shakeStrenght);
    }

    void Start()
    {
        _answerChecker.OnAnswerAccepted.AddListener(c => ShakeCell(c));
    }
}

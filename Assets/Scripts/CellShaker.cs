using DG.Tweening;
using UnityEngine;

public class CellShaker : MonoBehaviour
{
    [SerializeField]
    private float _shakeDuration;
    [SerializeField]
    private float _shakeStrenght;
    [SerializeField]
    private float _cellBounceDuration;
    [SerializeField]
    private AnswerChecker _answerChecker;

    public void ShakeCell(Cell cell)
    {
        cell.transform.DOShakePosition(_shakeDuration, _shakeStrenght);
    }

    public void BounceCell(Cell cell)
    {
        cell.transform.DOScale(new Vector3(0.5f, 0.5f, 0.5f), 0.01f);
        cell.transform.DOScale(new Vector3(1f, 1f, 1f), _cellBounceDuration);
    }

    void Start()
    {
        _answerChecker.OnAnswerRejected.AddListener(c => ShakeCell(c));
        _answerChecker.OnAnswerAcceptedStart.AddListener(c => BounceCell(c));
    }
}

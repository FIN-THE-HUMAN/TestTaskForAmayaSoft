using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickParticleSystemController : MonoBehaviour
{
    [SerializeField]
    private GameObject _particleSystem;
    private Vector2 mousePos;
    void Start()
    {
        _particleSystem.SetActive(false);
    }

    private IEnumerator WaitAndStopEmission()
    {
        yield return new WaitForSeconds(0.3f);
        _particleSystem.SetActive(false);
    }

    public void ReactToRightAnswer()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _particleSystem.SetActive(true);
        _particleSystem.transform.position = new Vector3(mousePos.x, mousePos.y, 0);

        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(WaitAndStopEmission());
        }
    }
}

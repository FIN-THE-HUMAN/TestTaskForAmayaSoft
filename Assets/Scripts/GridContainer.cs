using UnityEngine;
using UnityEngine.UI;

public class GridContainer : MonoBehaviour
{
    public Cell[] Cells;

    void Awake()
    {
        Cells = gameObject.GetComponentsInChildren<Cell>();
    }
}

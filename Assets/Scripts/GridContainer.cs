using UnityEngine;
using UnityEngine.UI;

public class GridContainer : MonoBehaviour
{
    public Cell[] Cells;

    void Start()
    {
        Cells = gameObject.GetComponentsInChildren<Cell>();
    }
}

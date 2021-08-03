using UnityEngine;

public class GridContainer : MonoBehaviour
{
    public Cell[] Cells;

    void Awake()
    {
        Cells = gameObject.GetComponentsInChildren<Cell>();
    }
}

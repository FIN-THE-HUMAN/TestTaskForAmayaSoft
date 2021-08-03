using UnityEngine;

public class LevelsGenerator : MonoBehaviour
{
    public CellsPicturesAndNamesSet[] CellsPicturesSets;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GenerateLevel() 
    {
        
    }
}

[System.Serializable]
public class CellsPicturesAndNamesSet
{
    public PictureAndName[] CellsPictures;
}

[System.Serializable]
public class PictureAndName
{
    public string Name;
    public Sprite Picture;
}

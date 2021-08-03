using System;
using UnityEngine;

public class LevelsGenerator : MonoBehaviour
{
    public LevelOptions[] Levels;
    [Space]
    public TaskInitializer TaskInitializer;
    public CellsPicturesAndNamesSet[] CellsPicturesSets;

    public void GenerateLevel() 
    {
        if (CellsPicturesSets.Length == 0) throw new IndexOutOfRangeException("There are no CellsPicturesSets");
        var randomSet = CellsPicturesSets[UnityEngine.Random.Range(0, CellsPicturesSets.Length)];

        if (randomSet.PictureAndNamePairs.Length == 0) throw new IndexOutOfRangeException("current CellsPicturesSets is empty");
        var answer = randomSet.PictureAndNamePairs[UnityEngine.Random.Range(0, randomSet.PictureAndNamePairs.Length)];

        TaskInitializer.SetAnswer(answer.Name, answer.Picture);
        Debug.Log("Level Generated");
    }
}

[System.Serializable]
public class CellsPicturesAndNamesSet
{
    public PictureAndNamePair[] PictureAndNamePairs;
}

[System.Serializable]
public class PictureAndNamePair
{
    public string Name;
    public Sprite Picture;
}

[System.Serializable]
public class LevelOptions
{
    public int gridHeight;
    public int gridWidth;
}

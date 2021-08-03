using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private LevelsGenerator _levelsGenerator;

    public void ResetLevels()
    {
        _levelsGenerator.ResetLevels();
    }
}

using System.Collections;
using System.Collections.Generic;
using UI.Screens.LevelInfo;
using UnityEngine;

public class InfoLevelCloser : MonoBehaviour
{
    [SerializeField] private LevelInfo[] _levelInfos;

    public void CloseAllScreen()
    {
        foreach (var levelInfo in _levelInfos)
            levelInfo.Close();
    }
}
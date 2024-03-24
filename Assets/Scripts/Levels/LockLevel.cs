using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Levels;
using SaveAndLoad;
using UnityEngine;

public class LockLevel : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private Load _load;
    [SerializeField] private Level _level;

    /*private void Awake()
    {
        LevelState status = (LevelState) _load.Get(Save.LevelStatus + _index, 0);
        Debug.Log("статус " + status);

        if (status == LevelState.Locked)
        {
            _level.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }*/
    
    private void Start()
    {
        LevelState status = (LevelState) _load.Get(Save.LevelStatus + _index, 0);
        // Debug.Log("статус " + status);

        if (status == LevelState.Locked)
        {
            _level.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
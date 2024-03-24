using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using SaveAndLoad;
using UnityEngine;

public class LockFence : MonoBehaviour
{
    [SerializeField] private int _index;
    [SerializeField] private Load _load;
    [SerializeField] private Color _colorLock;
    [SerializeField] private Color _colorUnLock;
    [SerializeField] private ParticleSystem _fenceEffect;

    private void Start()
    {
        LevelState status = (LevelState) _load.Get(Save.LevelStatus + _index, 0);

        var effect = _fenceEffect.main;

        if (status != LevelState.Locked)
        {
            effect.startColor = _colorUnLock;
            _fenceEffect.Play();
        }
    }

    /*private void Awake()
    {
        LevelState status = (LevelState) _load.Get(Save.LevelStatus + _index, 0);
        
        Debug.Log("статус " + status);
        
        var effect = _fenceEffect.main;

        if (status != LevelState.Locked)
        {
            effect.startColor = _colorUnLock;
        }
    }*/
}
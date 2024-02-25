using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : EndScreen
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private BuffCounter _buffCounter;
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private TMP_Text _buffCollected;

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += Open;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= Open;
    }

    public void SetTime(string timer)
    {
        _timer.text = timer;
    }

    private void SetValue()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timer;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private VictoryScreen _victoryScreen;

    private Stopwatch stopwatch;
    private float _startTime;
    private string _timeString;
    private bool _levelComplite = false;

    void Start()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    private void Update()
    {
        if (_levelComplite)
            return;

        float elapsedTime = Time.time - _startTime;
        TimeSpan timeSpan = TimeSpan.FromSeconds(elapsedTime);
        _timeString = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
        _timer.text = "Time: " + _timeString;
    }

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += OnStopTime;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= OnStopTime;
    }

    private void OnStopTime()
    {
        _victoryScreen.SetTime(_timeString);
        _levelComplite = true;
        // _timer.text = "Time: " + _timeString;
    }
}
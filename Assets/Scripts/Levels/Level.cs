using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelState { Locked, Unlocked, Completed }

public class Level : MonoBehaviour
{
    [SerializeField] private ParticleSystem _dontSelectedCircle;
    [SerializeField] private ParticleSystem _selectedCircle;
    [SerializeField] private ParticleSystem[] _effectsSelect;
    [SerializeField] private ParticleSystem _line;
    [SerializeField] private ParticleSystem _lineMove;
    [SerializeField] private Color _notPassedColor;
    [SerializeField] private Color _passedColor;
    [SerializeField] private Color _notOpenColor;
    [SerializeField] private Level _nextLevel;
    [SerializeField] private Level _previousLevel;

    [SerializeField] private CameraDistance _cameraDistance;

    [SerializeField] private bool _isPassed = false;
    [SerializeField] private bool _isOpen = false;
    public bool IsPassed => _isPassed;
    public bool IsOpen => _isOpen;
    public LevelState state;
    private void Start()
    {
        var module = _dontSelectedCircle.main;
        
        switch (state)
        {
            case LevelState.Locked:
                module.startColor = _notOpenColor;
                break;
            case LevelState.Unlocked:
                module.startColor= _notPassedColor;
                break;
            case LevelState.Completed:
                module.startColor = _passedColor;
                break;
        }
        
        SetLevels(this, _nextLevel);
        
        
        
        
        
        
        /*var module = _dontSelectedCircle.main;
        module.startColor = _isPassed ? _passedColor : _notPassedColor;

        if (_previousLevel != null)
        {
            if (!_previousLevel.IsPassed)
                module.startColor = _notOpenColor;
            else
                module.startColor = _isPassed ? _passedColor : _notPassedColor;
        }

        if (_nextLevel != null)
            SetLevels(this, _nextLevel);
            // SetLevels(_isPassed, _nextLevel.IsPassed);*/
    }

    private void OnMouseDown()
    {
        foreach (ParticleSystem effect in _effectsSelect)
            effect.Play();

        _dontSelectedCircle.Stop();
        _selectedCircle.Play();

        _cameraDistance.MoveCameraToTarget(transform);
        /*var module = _dontSelectedCircle.main;
        module.startColor = _color;*/
    }

    public void SetLevels(Level level1Passed, Level level2Passed)
    {
        
        var moduleMain = _line.main;
        
        if (this.state == LevelState.Completed && _nextLevel.state == LevelState.Completed)
        {
            moduleMain.startColor = _passedColor;
            _lineMove.Play();
        }
        else if (this.state == LevelState.Unlocked && _nextLevel.state == LevelState.Unlocked||this.state == LevelState.Completed&& _nextLevel.state == LevelState.Unlocked)
        {
            moduleMain.startColor = _notPassedColor;
        }
        else
        {
            moduleMain.startColor = _notOpenColor;
        }
        
        
        
        
        
        
        
        
        
        /*var moduleMain = _line.main;

        if (level1Passed.IsOpen && level2Passed.IsOpen)
        {
            moduleMain.startColor = level1Passed._isPassed && level2Passed.IsPassed ? _passedColor : _notPassedColor;
        }
        else
        {
            moduleMain.startColor = _notOpenColor;
        }
            


        if (level1Passed.IsPassed && level2Passed.IsPassed)
        {
            _lineMove.Play();
        }*/
    }


    /*public void SetLevels(bool level1Passed, bool level2Passed)
    {
        var moduleMain = _line.main;
        moduleMain.startColor = level1Passed && level2Passed ? _passedColor : _notPassedColor;

        if (level1Passed && level2Passed)
        {
            _lineMove.Play();
        }

        /#1#/ Устанавливаем цвет для кругов
        level1Circle.color = level1Passed ? passedColor : notPassedColor;
        level2Circle.color = level2Passed ? passedColor : notPassedColor;

        // Устанавливаем цвет для линии
        levelLinkLine.color = level1Passed && level2Passed ? passedColor : notPassedColor;#1#
    }*/
}
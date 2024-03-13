using System;
using System.Collections;
using System.Collections.Generic;
using CameraFiles;
using Enum;
using UnityEngine;

public class Level : MonoBehaviour
{
    [Header("Particles")] [SerializeField] private ParticleSystem _dontSelectedCircle;
    [SerializeField] private ParticleSystem _selectedCircle;
    [SerializeField] private ParticleSystem[] _effectsSelect;
    [SerializeField] private ParticleSystem[] _line;
    [SerializeField] private ParticleSystem[] _lineMove;
    [SerializeField] private LevelInfo _levelInfo;
    [SerializeField] private LevelInfo[] _levelsInfo;
    [SerializeField] private Color _notPassedColor;
    [SerializeField] private Color _passedColor;
    [SerializeField] private Color _notOpenColor;
    [SerializeField] private Level[] _nextLevel;
    [SerializeField] private Level _previousLevel;
    [SerializeField] private Level[] _allLevels;
    [SerializeField] private LevelCubeJumping _levelCubeJumping;
    [SerializeField] private CameraDistance _cameraDistance;

    [SerializeField] private bool _isPassed = false;
    [SerializeField] private bool _isOpen = false;
    [SerializeField] private Load _load;
    [SerializeField] private int _index;

    public Level[] Nextlevel => _nextLevel;
    public int Index => _index;
    public bool IsPassed => _isPassed;
    public bool IsOpen => _isOpen;

    private LevelState state;

    private Color _currentColor;

    /*private void Awake()
    {
        var module = _dontSelectedCircle.main;
      
        switch (state)
        {
            case LevelState.Locked:
                ColorChanger(_notOpenColor);
                break;
            case LevelState.Unlocked:
                _levelCubeJumping.enabled = true;
                ColorChanger(_notPassedColor);
                break;
            case LevelState.Completed:
                ColorChanger(_passedColor);
                break;
        }

        foreach (var level in _nextLevel)
        {
            SetLevels(this, level);
        }
    }*/

    public void Init(LevelState levelState)
    {
        state = levelState;

        switch (levelState)
        {
            case LevelState.Locked:
                ColorChanger(_notOpenColor);
                break;
            case LevelState.Unlocked:
                _levelCubeJumping.enabled = true;
                ColorChanger(_notPassedColor);
                break;
            case LevelState.Completed:
                ColorChanger(_passedColor);
                break;
        }

        /*
        foreach (var level in _nextLevel)
        {
            SetLevels(this, level);
        }*/
    }

    public void SetLevels()
    {
        foreach (var level in _nextLevel)
        {
            SetLevels(this, level);
        }
    }
    /*private void Start()
    {
        var module = _dontSelectedCircle.main;

        switch (state)
        {
            case LevelState.Locked:
                ColorChanger(_notOpenColor);
                break;
            case LevelState.Unlocked:
                _levelCubeJumping.enabled = true;
                ColorChanger(_notPassedColor);
                break;
            case LevelState.Completed:
                ColorChanger(_passedColor);
                break;
        }

        foreach (var level in _nextLevel)
        {
            SetLevels(this, level);
        }
    }*/

    private void OnMouseDown()
    {
        foreach (Level level in _allLevels)
        {
            level.StopParticles();
        }

        foreach (ParticleSystem effect in _effectsSelect)
            effect.Play();

        // _dontSelectedCircle.Stop();
        _selectedCircle.Play();
        _cameraDistance.MoveCameraToTarget(transform);
        /*_levelInfo.SetActive(true);
        _levelInfo.GetComponent<Animator>().Play("LevelCubeInfoScreenUp");*/
        foreach (LevelInfo levelInfo in _levelsInfo)
        {
            levelInfo.Close();
        }

        _levelInfo.Open();
    }

    public void StopParticles()
    {
        _selectedCircle.Stop();

        for (int i = 0; i < _effectsSelect.Length; i++)
        {
            _effectsSelect[i].Stop();
        }
    }

    private void ColorChanger(Color color)
    {
        var module = _dontSelectedCircle.main;
        var selectCircle = _selectedCircle.main;
        module.startColor = color;
        _currentColor = color;
        selectCircle.startColor = color;

        for (int i = 0; i < _effectsSelect.Length; i++)
        {
            var effectColor = _effectsSelect[i].main;
            effectColor.startColor = color;
        }
    }

    public void SetLevels(Level level1Passed, Level level2Passed)
    {
        if (_nextLevel.Length > 0)
        {
            for (int i = 0; i < _nextLevel.Length; i++)
            {
                var moduleMain = _line[i].main;

                // Debug.Log("STATELINE " + state  +" , " + _nextLevel[i].state);

                if (this.state == LevelState.Completed && _nextLevel[i].state == LevelState.Completed)
                {
                    moduleMain.startColor = _passedColor;
                    _lineMove[i].Play();
                }
                else if (this.state == LevelState.Unlocked && _nextLevel[i].state == LevelState.Unlocked ||
                         this.state == LevelState.Completed && _nextLevel[i].state == LevelState.Unlocked ||
                         this.state == LevelState.Unlocked && _nextLevel[i].state == LevelState.Completed)
                {
                    // Debug.Log("НЕ Проден");
                    moduleMain.startColor = _notPassedColor;
                }
                else
                {
                    // Debug.Log("Не открыт");
                    moduleMain.startColor = _notOpenColor;
                }
            }
        }
    }
}
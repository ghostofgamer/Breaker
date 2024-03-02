using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BrickCounter : MonoBehaviour
{
    [SerializeField] private BonusCounter _bonusCounter;
    [SerializeField] private TMP_Text _brickCountTxt;
    [SerializeField] private TMP_Text _brickSmashedTxt;
    [SerializeField] private ScoreCounter _scoreCounter;

    private int _bricksSmashedCount;
    private List<Brick> _bricks;
    private int _brickCount = 0;
    private int _score = 5;
    private int _remainingAmountHelp = 3;
    private bool _isRemainingActivated;

    public event UnityAction AllBrickDestory;
    public event UnityAction BricksDestructionHelp;

    public void ChangeValue(int reward)
    {
        _brickCount--;
        _bricksSmashedCount++;
        _bonusCounter.AddBonus(reward);
        ShowInfo();
        _scoreCounter.IncreaseScore(_score);

        if (_brickCount <= _remainingAmountHelp)
        {
            if (!_isRemainingActivated)
            {
                BricksDestructionHelp?.Invoke();
                _isRemainingActivated = true;
            }
        }

        if (_brickCount <= 0)
        {
            Debug.Log("Victory");
            AllBrickDestory?.Invoke();
        }
    }

    public void AddBricks(int bricksCount)
    {
        _brickCount++;
        ShowInfo();
    }

    private void ShowInfo()
    {
        _brickCountTxt.text = _brickCount.ToString();
        _brickSmashedTxt.text = _bricksSmashedCount.ToString();
    }

    public string GetAmountSmashed()
    {
        return _bricksSmashedCount.ToString();
    }
}
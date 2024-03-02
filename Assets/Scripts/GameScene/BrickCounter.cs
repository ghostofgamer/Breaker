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

    private int _score = 5;

    private bool _isRemainingActivated;

    public event UnityAction AllBrickDestory;
    public event UnityAction BricksDestructionHelp;

    public int RemainingAmountHelp { get; private set; } = 3;
    public int BrickCount { get; private set; }

    public void ChangeValue(int reward)
    {
        BrickCount--;
        _bricksSmashedCount++;
        _bonusCounter.AddBonus(reward);
        ShowInfo();
        _scoreCounter.IncreaseScore(_score);

        if (BrickCount <= RemainingAmountHelp)
        {
            if (!_isRemainingActivated)
            {
                BricksDestructionHelp?.Invoke();
                _isRemainingActivated = true;
            }
        }

        if (BrickCount <= 0)
        {
            Debug.Log("Victory");
            AllBrickDestory?.Invoke();
        }
    }

    public void AddBricks(int bricksCount)
    {
        BrickCount++;
        ShowInfo();
    }

    private void ShowInfo()
    {
        _brickCountTxt.text = BrickCount.ToString();
        _brickSmashedTxt.text = _bricksSmashedCount.ToString();
    }

    public string GetAmountSmashed()
    {
        return _bricksSmashedCount.ToString();
    }
}
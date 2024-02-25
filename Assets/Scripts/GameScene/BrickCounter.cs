using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class BrickCounter : MonoBehaviour
{
    [SerializeField] private Transform _bricksContainer;
    [SerializeField] private BonusCounter _bonusCounter;
    [SerializeField] private TMP_Text _brickCountTxt;
    [SerializeField] private TMP_Text _brickSmashedTxt;

    private int _bricksSmashedCount;
    private List<Brick> _bricks;
    private int _brickCount = 0;
    
    public event UnityAction AllBrickDestory;
    
    private void Start()
    {
        _brickCount = _bricksContainer.childCount;
        ShowInfo();
    }

    public void ChangeValue(int reward)
    {
        _brickCount--;
        _bricksSmashedCount++;
        _bonusCounter.AddBonus(reward);
        ShowInfo();

        if (_brickCount <= 0)
        {
            Debug.Log("Victory");
            AllBrickDestory?.Invoke();
        }
    }

    public void AddBricks(int bricksCount)
    {
        _brickCount += bricksCount;
        ShowInfo();
    }
    
    private void ShowInfo()
    {
        _brickCountTxt.text = _brickCount.ToString();
        _brickSmashedTxt.text = _bricksSmashedCount.ToString();
    }
}
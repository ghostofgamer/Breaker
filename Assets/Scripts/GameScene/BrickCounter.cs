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
    
    private List<Brick> _bricks;
    private int _brickCount = 0;
    
    private event UnityAction AllBrickDestory;
    
    private void Start()
    {
        _brickCount = _bricksContainer.childCount;
        ShowInfo();
        /*_bricks = new List<Brick>();

        for (int i = 0; i < _bricksContainer.childCount; i++)
        {
            _bricks.Add(_bricksContainer.GetChild(i).GetComponent<Brick>());
        }*/
    }

    public void ChangeValue(int reward)
    {
        _brickCount--;
        _bonusCounter.ChangeValue(reward);
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
    }
}
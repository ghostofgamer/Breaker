using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [Range(0, 50000)] [SerializeField] private int _startMoney;
    [SerializeField]private  TMP_Text _moneyText;
    
    private int _money;
    
    private void Start()
    {
        _money = _startMoney;
        ShowInfo();
    }

    public void AddMoney(int amount)
    {
        _money += amount;
        ShowInfo();
    }
    
    public void RemoveMoney(int amount)
    {
        _money -= amount;
        ShowInfo();
    }

    private void ShowInfo()
    {
        _moneyText.text = _money.ToString();
    }
}
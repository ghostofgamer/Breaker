using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    [Range(0, 50000)] [SerializeField] private int _startMoney;
    [SerializeField]private  TMP_Text _moneyText;
    [SerializeField]private Save _save;
    [SerializeField ] private Load _load;
    
    private int _money;
    
    public int Money =>_money;
    
    private void Start()
    {
        _money = _load.Get(Save.Money, _startMoney);
        ShowInfo();
    }

    public void AddMoney(int amount)
    {
        _money += amount;
        SaveMoney();
        ShowInfo();
    }
    
    public void RemoveMoney(int amount)
    {
        _money -= amount;
        SaveMoney();
        ShowInfo();
    }

    private void ShowInfo()
    {
        _moneyText.text = _money.ToString();
    }

    private void SaveMoney()
    {
        _save.SetData(Save.Money, _money);
    }
}
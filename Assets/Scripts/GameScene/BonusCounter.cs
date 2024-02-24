using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _bonusTxt;
    
    private int _amountBonuses = 0;

    private void Start()
    {
        ShowInfo();
    }

    public void ChangeValue(int reward)
    {
        _amountBonuses += reward;
        ShowInfo();
    }

    private void ShowInfo()
    {
        _bonusTxt.text = _amountBonuses.ToString();
    }
}

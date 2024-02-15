using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeButton : AbstractButton
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;
    [SerializeField] private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Save _save;
    [SerializeField] private Buffs _buffElement;
    [SerializeField] private BuffInfo _buff;

    protected override void OnClick()
    {
        if (_wallet.Money >= _price)
            MakeDeal();
    }

    private void MakeDeal()
    {
        _save.SetData(_buffElement.ToString(), 1);
        _buff.ChangeValue();
        _closeInfoButton.ScreenClose();
        _wallet.RemoveMoney(_price);
    }
}
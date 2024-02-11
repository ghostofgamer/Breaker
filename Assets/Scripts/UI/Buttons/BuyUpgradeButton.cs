using System.Collections;
using System.Collections.Generic;
using Enum;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeButton : AbstractButton
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private GameObject _infoButton;
    [SerializeField] private GameObject _buyUpgradeButton;
    [SerializeField] private Image _upgradeUpLevel;
    [SerializeField] private Color _color;
    [SerializeField] private int _price;
    [SerializeField]private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Save _save;
    [SerializeField] private Buffs _buffElement;
    [SerializeField]private Buff _buff;

    protected override void OnClick()
    {
        if (_wallet.Money >= _price)
            BuyUpgrade();
    }

    /*private void ChangeValue()
    {
        _infoButton.SetActive(true);
        _buyUpgradeButton.SetActive(false);
        _upgradeUpLevel.color = _color;
        _closeInfoButton.ScreenClose();
    }*/

    private void BuyUpgrade()
    {
        _save.SetData(_buff.ToString(),1);
        // ChangeValue();
        _buff.ChangeValue();
        _closeInfoButton.ScreenClose();
        _wallet.RemoveMoney(_price);
    }
}
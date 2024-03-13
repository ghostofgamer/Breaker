using System.Collections;
using System.Collections.Generic;
using Enum;
using MainMenu.Shop;
using PlayerFiles;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BuySkinBallButton : AbstractButton
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;
    [SerializeField] private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Skin _skin;
    [SerializeField] private BallSkins _ballSkins;
    [SerializeField] private Save _save;

    private bool _isBuyed;
    private int _purchased = 1;

    protected override void OnClick()
    {
        BuySkin();
    }

    private void BuySkin()
    {
        if (TryBuySkin())
            ChangeValue();
        else
            return;
    }

    private bool TryBuySkin()
    {
        if (_wallet.Money >= _price)
            return true;

        return false;
    }

    private void ChangeValue()
    {
        _save.SetData(_ballSkins.ToString(), _purchased);
        _wallet.RemoveMoney(_price);
        _closeInfoButton.ScreenClose();
        Button.interactable = false;
        _skin.ChangeValue();
    }
}
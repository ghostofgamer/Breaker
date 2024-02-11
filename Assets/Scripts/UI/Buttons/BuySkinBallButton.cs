using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BuySkinBallButton : AbstractButton
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;
    [SerializeField] private GameObject _skinBlock;
    [SerializeField] private GameObject _nameToClose;
    [SerializeField] private GameObject _nameToOpen;
    [SerializeField] private InfoButton _infoButton;
    [SerializeField] private Image _locked;
    [SerializeField] private CloseInfoScreenButton _closeInfoButton;

    private bool _isBuyed;

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
        _wallet.RemoveMoney(_price);
        _closeInfoButton.ScreenClose();
        Button.interactable = false;
        _skinBlock.SetActive(false);
        _infoButton.gameObject.SetActive(false);
        _locked.gameObject.SetActive(false);
        _nameToClose.SetActive(false);
        _nameToOpen.SetActive(true);
    }
}
using System.Collections;
using System.Collections.Generic;
using MainMenu.Shop.Platforms;
using SaveAndLoad;
using UnityEngine;

public class BuyPlatformaSkinButton : AbstractButton
{
    [SerializeField] private int _index;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;
    [SerializeField]private PlatformaSkinShop _platformaSkinShop;
    [SerializeField]private CloseInfoScreenButton _closeInfoScreen;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;

    protected override void OnClick()
    {
        BuySkin();
    }

    private void BuySkin()
    {
        if (_wallet.Money >= _price)
        {
            _wallet.RemoveMoney(_price);
            _platformaSkinShop.BuyCapsuleSkin(_index);
            _closeInfoScreen.ScreenClose();
        }
    }
}
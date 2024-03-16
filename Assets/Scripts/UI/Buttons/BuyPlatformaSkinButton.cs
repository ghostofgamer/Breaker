using System.Collections;
using System.Collections.Generic;
using MainMenu.Shop.Platforms;
using PlayerFiles;
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
    [SerializeField]private AudioSource _audioSource;
    [SerializeField]private AudioClip _audioClip;
    
    protected override void OnClick()
    {
        BuySkin();
    }

    private void BuySkin()
    {
        if (_wallet.Money >= _price)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _wallet.RemoveMoney(_price);
            _platformaSkinShop.BuyCapsuleSkin(_index);
            _closeInfoScreen.ScreenClose();
        }
        else
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}
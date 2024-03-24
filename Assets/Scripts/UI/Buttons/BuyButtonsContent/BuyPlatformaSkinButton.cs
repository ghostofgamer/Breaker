using MainMenu.Shop.Platforms;
using UnityEngine;

public class BuyPlatformaSkinButton : BuyButton
{
    [SerializeField] private int _index;
    /*[SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;*/
    [SerializeField]private PlatformaSkinShop _platformaSkinShop;
    // [SerializeField]private CloseInfoScreenButton _closeInfoScreen;
    /*[SerializeField] private Load _load;
    [SerializeField] private Save _save;*/
    /*[SerializeField]private AudioSource _audioSource;
    [SerializeField]private AudioClip _audioClip;*/

    /*protected override void OnClick()
    {
        BuySkin();
    }*/

    protected override void Buy()
    {
        
        _platformaSkinShop.BuyCapsuleSkin(_index);
        
        /*if (Wallet.Money >= Price)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            Wallet.RemoveMoney(Price);
            _platformaSkinShop.BuyCapsuleSkin(_index);
            _closeInfoScreen.ScreenClose();
        }
        else
        {
            _audioSource.PlayOneShot(_audioClip);
        }*/
    }

    /*private void BuySkin()
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
    }*/
}
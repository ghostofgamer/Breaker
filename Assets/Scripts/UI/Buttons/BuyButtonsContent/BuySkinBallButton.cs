using Enum;
using MainMenu.Shop;
using SaveAndLoad;
using UnityEngine;

public class BuySkinBallButton : BuyButton
{
    /*[SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;*/
    // [SerializeField] private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Skin _skin;
    [SerializeField] private BallSkins _ballSkins;
    [SerializeField] private Save _save;
    /*[SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;*/
    /*[SerializeField] private TMP_Text _priceTxt;
    [SerializeField]private Color _color;*/
    
    private bool _isBuyed;
    private int _purchased = 1;

    /*
    protected override void OnEnable()
    {
        base.OnEnable();
        _wallet.ValueChanged += CheckSolvency;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _wallet.ValueChanged += CheckSolvency;
    }

    private void Start()
    {
        CheckSolvency();
    }*/
    
    /*protected override void OnClick()
    {
        BuySkin();
    }

    private void BuySkin()
    {
        if (TryBuySkin())
            ChangeValue();
        else
        {
            _audioSource.PlayOneShot(_audioClip);
            return;
        }
    }*/

    protected override void Buy()
    {
        _save.SetData(_ballSkins.ToString(), _purchased);
        Button.interactable = false;
        _skin.ChangeValue();
        /*if (TryBuySkin())
            ChangeValue();
        else
        {
            _audioSource.PlayOneShot(_audioClip);
            return;
        }*/
    }

    /*private bool TryBuySkin()
    {
        if (Wallet.Money >= Price)
            return true;

        return false;
    }

    private void ChangeValue()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _save.SetData(_ballSkins.ToString(), _purchased);
        Wallet.RemoveMoney(Price);
        _closeInfoButton.ScreenClose();
        Button.interactable = false;
        _skin.ChangeValue();
    }*/
    
    /*private void CheckSolvency()
    {
        if (Wallet.Money < _price)
            _priceTxt.color = _color;
    }*/
}
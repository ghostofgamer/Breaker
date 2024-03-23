using Enum;
using MainMenu.Shop;
using SaveAndLoad;
using UnityEngine;

public class BuyUpgradeButton : BuyButton
{
    /*[SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;*/
    // [SerializeField] private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Save _save;
    [SerializeField] private Buffs _buffElement;
    [SerializeField] private BuffInfo _buff;
    /*[SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;*/
    /*[SerializeField] private TMP_Text _priceTxt;
    [SerializeField]private Color _color;*/

    /*protected override void OnEnable()
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
        if (_wallet.Money >= _price)
            MakeDeal();
        else
            _audioSource.PlayOneShot(_audioClip);
    }*/

    /*private void MakeDeal()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _save.SetData(_buffElement.ToString(), 3);
        _buff.ChangeValue();
        _closeInfoButton.ScreenClose();
        Wallet.RemoveMoney(Price);
    }*/

    protected override void Buy()
    {
        _save.SetData(_buffElement.ToString(), 3);
        _buff.ChangeValue();
        
        /*if (Wallet.Money >= Price)
            MakeDeal();
        else
            _audioSource.PlayOneShot(_audioClip);*/
    }

    /*private void CheckSolvency()
    {
        if (_wallet.Money < _price)
            _priceTxt.color = _color;
    }*/
}
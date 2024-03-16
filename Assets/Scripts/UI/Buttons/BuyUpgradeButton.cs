using System.Collections;
using System.Collections.Generic;
using Enum;
using MainMenu.Shop;
using PlayerFiles;
using SaveAndLoad;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgradeButton : AbstractButton
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private int _price;
    [SerializeField] private CloseInfoScreenButton _closeInfoButton;
    [SerializeField] private Save _save;
    [SerializeField] private Enum.Buffs _buffElement;
    [SerializeField] private BuffInfo _buff;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;

    protected override void OnClick()
    {
        if (_wallet.Money >= _price)
            MakeDeal();
        else
            _audioSource.PlayOneShot(_audioClip);
    }

    private void MakeDeal()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        Debug.Log(_buffElement.ToString());
        _save.SetData(_buffElement.ToString(), 3);
        _buff.ChangeValue();
        _closeInfoButton.ScreenClose();
        _wallet.RemoveMoney(_price);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using MainMenu.Shop;
using PlayerFiles;
using SaveAndLoad;
using TMPro;
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
    [SerializeField] private TMP_Text _priceTxt;
    [SerializeField]private Color _color;

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
    }

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

    private void CheckSolvency()
    {
        if (_wallet.Money < _price)
            _priceTxt.color = _color;
    }
}
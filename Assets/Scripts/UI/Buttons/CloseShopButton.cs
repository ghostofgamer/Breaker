using System;
using System.Collections;
using System.Collections.Generic;
using CameraFiles;
using Levels;
using UI.Screens;
using UnityEngine;
using UnityEngine.UI;

public class CloseShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField] private Image[] _imagesActive;
    [SerializeField] private Image[] _backgroundImage;
    [SerializeField] private Color _currentColor;
    [SerializeField] private CloseShopButton[] _closeShopButtons;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private Level[] _levels;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField]private ShopScreen _shopScreen;

    protected override void OnClick()
    {
        // _audioSource.PlayOneShot(_audioSource.clip);
        
        if (_cameraMover != null && !_cameraMover.enabled)
            _cameraMover.enabled = true;
        
        if (_levels.Length > 0)
        {
            foreach (var level in _levels)
                level.GetComponent<BoxCollider>().enabled = true;
        }
        
        _shopScreen.Close();
        /*_screen.GetComponent<Animator>().Play("ShopScreenClose");
        _shopBackGround.BackGroundAlphaChange(1, 0);

        foreach (CloseShopButton close in _closeShopButtons)
            close.gameObject.SetActive(false);

        gameObject.SetActive(false);
        OffImages();*/
    }

    private void OffImages()
    {
        foreach (Image image in _imagesActive)
        {
            image.gameObject.SetActive(false);
        }

        foreach (Image image in _backgroundImage)
        {
            image.color = _currentColor;
        }
    }
}
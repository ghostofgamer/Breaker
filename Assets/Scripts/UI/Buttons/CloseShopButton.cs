using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private ShopBackGround _shopBackGround;

    [SerializeField] private Image[] _imagesActive;
    [SerializeField] private Image[] _backgroundImage;
    [SerializeField] private Color _currentColor;
    
    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenClose");
        _shopBackGround.BackGroundAlphaChange(1, 0);
        gameObject.SetActive(false);
        OffImages();
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
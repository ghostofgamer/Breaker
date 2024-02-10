using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField] private CloseShopButton _closeShopButton;
    [SerializeField] private Image[] _imagesActive;
    [SerializeField] private int _tabIndex;
    [SerializeField] private Image[] _backgroundImage;
    [SerializeField] private Color _newColor;
    [SerializeField] private GameObject[] _tabs;

    private Color _currentColor;

    private void Start()
    {
        _currentColor = _backgroundImage[_tabIndex].color;
    }

    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenOpen");
        _shopBackGround.BackGroundAlphaChange(0, 1);
        _closeShopButton.gameObject.SetActive(true);
        ActiveImage();
        ColorChanger();
        ActiveTab();
    }

    private void ActiveImage()
    {
        foreach (Image image in _imagesActive)
        {
            image.gameObject.SetActive(false);
        }

        _imagesActive[_tabIndex].gameObject.SetActive(true);
    }

    private void ColorChanger()
    {
        foreach (Image image in _backgroundImage)
            image.color = _currentColor;

        _backgroundImage[_tabIndex].color = _newColor;
    }

    private void ActiveTab()
    {
        foreach (GameObject tab in _tabs)
            tab.SetActive(false);

        _tabs[_tabIndex].SetActive(true);
    }
}
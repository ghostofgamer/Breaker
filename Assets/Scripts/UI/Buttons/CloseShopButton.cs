using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private ShopBackGround _shopBackGround;
    
    private void Start()
    {
        gameObject.SetActive(false);
    }

    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenClose");
        _shopBackGround.BackGroundAlphaChange(1,0);
        // gameObject.SetActive(false);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;

    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenClose");
    }
}
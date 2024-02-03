using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    
    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenOpen");
    }
}

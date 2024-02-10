using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : AbstractButton
{
    [SerializeField] private GameObject _screenInfo;
    [SerializeField] private ShopBackGround _shopBackGround;
    
    protected override void OnClick()
    {
        _screenInfo.SetActive(true);
        _screenInfo.GetComponent<Animator>().Play("InfoScreenOpen");
        _shopBackGround.BackGroundAlphaChange(0, 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopButton : AbstractButton
{
    [SerializeField] private GameObject _screen;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField]private CloseShopButton _closeShopButton;
    [SerializeField] private Image[] _imagesActive;
    [SerializeField] private int _tabIndex;
    
    protected override void OnClick()
    {
        _screen.GetComponent<Animator>().Play("ShopScreenOpen");
        _shopBackGround.BackGroundAlphaChange(0,1);
        _closeShopButton.gameObject.SetActive(true);
        ActiveImage();
    }

    private void ActiveImage()
    {
        foreach (Image image in _imagesActive)
        {
            image.gameObject.SetActive(false);
        }
        
        _imagesActive[_tabIndex].gameObject.SetActive(true);
    }
}
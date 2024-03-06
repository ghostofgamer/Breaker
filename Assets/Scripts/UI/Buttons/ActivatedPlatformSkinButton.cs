using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatedPlatformSkinButton : AbstractButton
{
    [SerializeField] private PlatformaSkinShop _platformaSkinShop;
    [SerializeField] private int _index;
    
    protected override void OnClick()
    {
        ActivatedSkin();
    }

    private void ActivatedSkin()
    {
        _platformaSkinShop.ActivateCapsuleSkin(_index);
    }
}

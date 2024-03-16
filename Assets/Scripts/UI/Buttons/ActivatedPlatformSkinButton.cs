using System.Collections;
using System.Collections.Generic;
using MainMenu.Shop.Platforms;
using UnityEngine;

public class ActivatedPlatformSkinButton : AbstractButton
{
    [SerializeField] private PlatformaSkinShop _platformaSkinShop;
    [SerializeField] private int _index;
    [SerializeField]private AudioSource _audioSource;
    
    protected override void OnClick()
    {
        ActivatedSkin();
    }

    private void ActivatedSkin()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _platformaSkinShop.ActivateCapsuleSkin(_index);
    }
}

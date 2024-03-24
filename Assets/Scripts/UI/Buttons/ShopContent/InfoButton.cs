using System.Collections;
using System.Collections.Generic;
using UI;
using UI.Screens;
using UnityEngine;

public class InfoButton : AbstractButton
{
    [SerializeField] private GameObject _screenInfo;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField]private UIAnimations _uiAnimations;

    protected override void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _screenInfo.SetActive(true);
        _uiAnimations.Open();
        // _screenInfo.GetComponent<Animator>().Play("InfoScreenOpen");
        _shopBackGround.BackGroundAlphaChange(0, 1);
    }
}
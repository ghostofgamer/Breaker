using System.Collections;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;

public class InfoButton : AbstractButton
{
    [SerializeField] private GameObject _screenInfo;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField] private AudioSource _audioSource;

    protected override void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _screenInfo.SetActive(true);
        _screenInfo.GetComponent<Animator>().Play("InfoScreenOpen");
        _shopBackGround.BackGroundAlphaChange(0, 1);
    }
}
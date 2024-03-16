using System.Collections;
using System.Collections.Generic;
using UI.Screens;
using UnityEngine;

public class CloseInfoScreenButton : AbstractButton
{
    [SerializeField] private GameObject _infoScreen;
    [SerializeField] private ShopBackGround _shopBackGround;
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;

    protected override void OnClick()
    {
        ScreenClose();
    }

    public void ScreenClose()
    {
        if (_audioSource != null)
            _audioSource.PlayOneShot(_audioSource.clip);

        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(InfoScreenClose());
    }

    private IEnumerator InfoScreenClose()
    {
        _infoScreen.GetComponent<Animator>().Play("InfoScreenClose");
        _shopBackGround.BackGroundAlphaChange(1, 0);
        yield return new WaitForSeconds(0.15f);
        _infoScreen.SetActive(false);
    }
}
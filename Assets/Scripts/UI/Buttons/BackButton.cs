using System;
using System.Collections;
using UI.Buttons;
using UI.Screens;
using UnityEngine;


public class BackButton : AbstractButton
{
    [SerializeField] private MainScreen _mainScreen;
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private GameObject _settingsButton;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.16f);

    private void Start()
    {
        CanvasValue(0);
    }

    protected override void OnClick()
    {
        StartCoroutine(ChangeOpenMenu());
    }

    private IEnumerator ChangeOpenMenu()
    {
        CanvasValue(0);
        _settingsScreen.GetComponent<FadeObject>().FadeOn();
        yield return _waitForSeconds;
        _settingsButton.SetActive(true);
        _mainScreen.GetComponent<FadeObject>().FadeOut();
    }
}
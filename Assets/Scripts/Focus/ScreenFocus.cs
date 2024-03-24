using System.Collections;
using System.Collections.Generic;
using Agava.WebUtility;
using UnityEngine;

public class ScreenFocus : MonoBehaviour
{
    // private AimInputButton _aimInputButton;
    private int _stop = 0;
    private int _play = 1;

    private void OnEnable()
    {
        Application.focusChanged += OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent += OnInBackgroundChangeWeb;
    }

    private void OnDisable()
    {
        Application.focusChanged -= OnInBackgroundChangeApp;
        WebApplication.InBackgroundChangeEvent -= OnInBackgroundChangeWeb;
    }

    /*public void Init(AimInputButton aimInputButton)
    {
        _aimInputButton = aimInputButton;
    }*/

    private void OnInBackgroundChangeApp(bool inApp)
    {
        SetValueAudio(!inApp);
        PauseGame(!inApp);
    }

    private void OnInBackgroundChangeWeb(bool isBackground)
    {
        /*if (isBackground)
            _aimInputButton.ReturnHide();*/

        SetValueAudio(isBackground);
        PauseGame(isBackground);
    }

    private void SetValueAudio(bool value)
    {
        AudioListener.pause = value;
    }

    private void PauseGame(bool value)
    {
        Time.timeScale = value ? _stop : _play;
    }
}

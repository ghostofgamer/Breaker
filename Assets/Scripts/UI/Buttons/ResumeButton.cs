using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResumeButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private CountDown _countDown;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    
    protected override void OnClick()
    {
        ResumeGame();
    }

    private void ResumeGame()
    {
        StartCoroutine(CloseSettings());
    }

    private IEnumerator CloseSettings()
    {
        _settingsScreen.Close();
        yield return _waitForSeconds;
        _countDown.GoResume();
        // Time.timeScale = 1;
    }
}

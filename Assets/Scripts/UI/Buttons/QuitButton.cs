using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitButton : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;
    
    private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
    private const string SceneName = "MainScene";
    
    protected override void OnClick()
    {
        CloseGame();
    }

    private void CloseGame()
    {
        StartCoroutine(Quit());
    }

    private IEnumerator Quit()
    {
        _settingsScreen.Close();
        yield return _waitForSeconds;
        SceneManager.LoadScene(SceneName);
    }
}

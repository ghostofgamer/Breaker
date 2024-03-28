using System.Collections;
using UI.Screens;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons.Settings
{
    public class QuitButton : AbstractButton
    {
        private const string SceneName = "MainScene";

        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);

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
            _audioSource.PlayOneShot(_audioSource.clip);
            _settingsScreen.Close();
            yield return _waitForSeconds;
            SceneManager.LoadScene(SceneName);
        }
    }
}
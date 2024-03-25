using System.Collections;
using UI.Screens;
using UnityEngine;

namespace UI.Buttons.Settings
{
    public class ResumeButton : AbstractButton
    {
        [SerializeField] private SettingsScreen _settingsScreen;
        [SerializeField] private CountDown _countDown;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);

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
            _audioSource.PlayOneShot(_audioSource.clip);
            _settingsScreen.Close();
            yield return _waitForSeconds;
            _countDown.GoResume();
        }
    }
}
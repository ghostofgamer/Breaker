using System.Collections;
using UI.Screens;
using UnityEngine;

namespace UI.Buttons
{
    public class SettingsButton : AbstractButton
    {
        [SerializeField]private MainScreen _mainScreen;
        [SerializeField]private SettingsScreen  _settingsScreen;
        [SerializeField] private GameObject _backButton;
        [SerializeField] private AudioSource _audioSource;
        // [SerializeField] private AudioClip _audioClip;
        
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.16f);

        protected override void OnClick()
        {
            StartCoroutine(ChangeOpenMenu());
        }

        private IEnumerator ChangeOpenMenu()
        {
            // _audioSource.PlayOneShot(_audioClip);
            // _audioSource.PlayOneShot(_audioSource.clip);
            _mainScreen.GetComponent<FadeObject>().FadeOn();
            yield return _waitForSeconds;
            _backButton.SetActive(true);
            _backButton.GetComponent<BackButton>().CanvasValue(1);
            transform.gameObject.SetActive(false);
            _settingsScreen.GetComponent<FadeObject>().FadeOut();
        }
    }
}

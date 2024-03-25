using System.Collections;
using UnityEngine;

namespace UI.Buttons.Settings
{
    public class SettingsButton : AbstractButton
    {
        [SerializeField] private BackButton _backButton;
        [SerializeField] private FadeObject _mainScreenFade;
        [SerializeField] private FadeObject _settingsScreenFade;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.16f);
        private int _alpha = 1;

        protected override void OnClick()
        {
            StartCoroutine(ChangeOpenMenu());
        }

        private IEnumerator ChangeOpenMenu()
        {
            _mainScreenFade.FadeOn();
            yield return _waitForSeconds;
            _backButton.gameObject.SetActive(true);
            _backButton.CanvasValue(_alpha);
            transform.gameObject.SetActive(false);
            _settingsScreenFade.FadeOut();
        }
    }
}
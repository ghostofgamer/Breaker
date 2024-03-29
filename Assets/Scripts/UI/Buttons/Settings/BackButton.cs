using System.Collections;
using MainMenu;
using UnityEngine;

namespace UI.Buttons.Settings
{
    public class BackButton : AbstractButton
    {
        [SerializeField] private GameObject _settingsButton;
        [SerializeField] private ScreenFader _mainScreenFade;
        [SerializeField] private ScreenFader _settingsScreenFade;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.16f);

        private void Start()
        {
            SetCanvasValue(0);
        }

        protected override void OnClick()
        {
            StartCoroutine(ChangeOpenMenu());
        }

        private IEnumerator ChangeOpenMenu()
        {
            SetCanvasValue(0);
            _settingsScreenFade.FadeOn();
            yield return _waitForSeconds;
            _settingsButton.SetActive(true);
            _mainScreenFade.FadeOut();
        }
    }
}
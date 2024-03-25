using System.Collections;
using MainMenu;
using UnityEngine;

namespace UI.Buttons.Settings
{
    public class BackButton : AbstractButton
    {
        [SerializeField] private GameObject _settingsButton;
        [SerializeField] private FadeObject _mainScreenFade;
        [SerializeField] private FadeObject _settingsScreenFade;

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
            _settingsScreenFade.FadeOn();
            yield return _waitForSeconds;
            _settingsButton.SetActive(true);
            _mainScreenFade.FadeOut();
        }
    }
}
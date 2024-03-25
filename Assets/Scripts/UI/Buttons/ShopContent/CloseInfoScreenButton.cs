using System.Collections;
using UI.Screens;
using UnityEngine;

namespace UI.Buttons.ShopContent
{
    public class CloseInfoScreenButton : AbstractButton
    {
        [SerializeField] private GameObject _infoScreen;
        [SerializeField] private ShopBackGround _shopBackGround;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UIAnimations _uiAnimations;

        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.15f);
        private int _startAlpha = 1;
        private int _endAlpha = 0;

        protected override void OnClick()
        {
            ScreenClose();
        }

        public void ScreenClose()
        {
            if (_audioSource != null)
                _audioSource.PlayOneShot(_audioSource.clip);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(InfoScreenClose());
        }

        private IEnumerator InfoScreenClose()
        {
            _uiAnimations.Close();
            _shopBackGround.BackGroundAlphaChange(_startAlpha, _endAlpha);
            yield return _waitForSeconds;
            _infoScreen.SetActive(false);
        }
    }
}
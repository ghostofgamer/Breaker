using System.Collections;
using UnityEngine;

namespace UI.Screens.EndScreens
{
    public abstract class EndScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UIAnimations _uiAnimations;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private int _alphaZero = 0;
        private int _alphaFull = 1;

        public virtual void OnOpen()
        {
            EnableScreen();
            _uiAnimations.Open();
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        public virtual void Close()
        {
            StartCoroutine(ScreenDeactivation());
        }

        private void EnableScreen()
        {
            _canvasGroup.alpha = _alphaFull;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }

        private void DisableScreen()
        {
            _canvasGroup.alpha = _alphaZero;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private IEnumerator ScreenDeactivation()
        {
            _uiAnimations.Close();
            _audioSource.PlayOneShot(_audioSource.clip);
            yield return _waitForSeconds;
            DisableScreen();
        }
    }
}
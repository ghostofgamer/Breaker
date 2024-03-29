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
            ChangeValue(_alphaFull, true, true);
            _uiAnimations.Open();
            _audioSource.PlayOneShot(_audioSource.clip);
        }

        public virtual void Close()
        {
            StartCoroutine(ScreenDeactivation());
        }

        private void ChangeValue(int alpha, bool interactable, bool blockRaycast)
        {
            _canvasGroup.alpha = alpha;
            _canvasGroup.interactable = interactable;
            _canvasGroup.blocksRaycasts = blockRaycast;
        }

        private IEnumerator ScreenDeactivation()
        {
            _uiAnimations.Close();
            _audioSource.PlayOneShot(_audioSource.clip);
            yield return _waitForSeconds;
            ChangeValue(_alphaZero, false, false);
        }
    }
}
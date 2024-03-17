using System.Collections;
using UnityEngine;

namespace UI.Screens.EndScreens
{
    public abstract class EndScreen : MonoBehaviour
    {
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private Animator _animator;
        [SerializeField]private AudioSource _audioSource;
    
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        public virtual void Open()
        {
            ChangeValue(1, true, true);
            _animator.Play("ScreenOpen");
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
            _animator.Play("ScreenClose");
            _audioSource.PlayOneShot(_audioSource.clip);
            yield return _waitForSeconds;
            ChangeValue(0, false, false);
        }
    }
}
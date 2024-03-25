using System.Collections;
using UnityEngine;

namespace ModificationFiles
{
    public class NameEffectAnimation : MonoBehaviour
    {
        private const string EffectNameAnimation = "EffectNameAnimation";

        [SerializeField] private Animator _animator;
        [SerializeField] private CanvasGroup _canvasGroup;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private Coroutine _coroutine;
        private int _alphaFull = 1;
        private int _alphaZero = 0;

        public void Show()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(ShowAnimation());
        }

        private IEnumerator ShowAnimation()
        {
            SetValue(_alphaFull);
            _animator.Play(EffectNameAnimation);
            yield return _waitForSeconds;
            SetValue(_alphaZero);
        }

        private void SetValue(int alpha)
        {
            _canvasGroup.alpha = alpha;
        }
    }
}
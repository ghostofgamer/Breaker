using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ShopBackGround : MonoBehaviour
    {
        private float _duration = 0.165f;
        private Coroutine _coroutine;
        private CanvasGroup _canvasGroup;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void BackGroundAlphaChange(int start, int end)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Fade(start, end));
        }

        private IEnumerator Fade(int startAlpha, int endAlpha)
        {
            float elapsedTime = 0f;

            if (_canvasGroup.alpha != endAlpha)
            {
                while (elapsedTime < _duration)
                {
                    elapsedTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime / _duration);
                    _canvasGroup.alpha = alpha;
                    yield return null;
                }
            }
        }
    }
}
using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class ShopBackGround : MonoBehaviour
    {
        private float _duration = 0.165f;
        private Coroutine _coroutine;

        public void BackGroundAlphaChange(int start, int end)
        {
            if(_coroutine!= null)
                StopCoroutine(_coroutine);
        
            _coroutine = StartCoroutine(Fade(start,end));
        }

        private IEnumerator Fade(int startAlpha,int needAlpha)
        {
            float elapsedTime = 0f;
            CanvasGroup canvas = GetComponent<CanvasGroup>();

            if (canvas.alpha != needAlpha)
            {
                while (elapsedTime < _duration)
                {
                    elapsedTime += Time.deltaTime;
                    float alpha = Mathf.Lerp(startAlpha, needAlpha, elapsedTime / _duration);
                    canvas.alpha = alpha;
                    yield return null;
                }
            }
        }
    }
}

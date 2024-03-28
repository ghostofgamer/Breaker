using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ModificationFiles
{
    public class BuffUIFade : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private float _duration;

        private int _fullFillAmount = 1;
        private float _elapsedTime;

        private void OnEnable()
        {
            StartCoroutine(FillOverTime(_duration));
        }

        public void Init(float duration)
        {
            _duration = duration;
        }

        private IEnumerator FillOverTime(float time)
        {
            _elapsedTime = 0f;

            while (_elapsedTime < time)
            {
                _elapsedTime += Time.deltaTime;
                _image.fillAmount = Mathf.Lerp(0, _fullFillAmount, _elapsedTime / time);
                yield return null;
            }

            _image.fillAmount = _fullFillAmount;
        }
    }
}
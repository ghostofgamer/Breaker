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

        private void OnEnable()
        {
            StartCoroutine(FillOverTime(_duration));
        }

        private IEnumerator FillOverTime(float time)
        {
            float currentTime = 0f;

            while (currentTime < time)
            {
                currentTime += Time.deltaTime;
                _image.fillAmount = Mathf.Lerp(0, _fullFillAmount, currentTime / time);
                yield return null;
            }

            _image.fillAmount = _fullFillAmount;
        }

        public void Init(float duration)
        {
            _duration = duration;
        }
    }
}
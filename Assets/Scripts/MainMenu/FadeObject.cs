using System.Collections;
using UnityEngine;

namespace MainMenu
{
    [RequireComponent(typeof(RectTransform))]
    public class FadeObject : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private RectTransform _rectTransform;
        private float _fadeDuration = 0.16f;
        private float _wight = 599.63f;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
        }

        public void FadeOn()
        {
            StartCoroutine(EnableFade(0, _audioClip));
        }

        public void FadeOut()
        {
            StartCoroutine(EnableFade(_wight, _audioSource.clip));
        }

        private IEnumerator EnableFade(float target, AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
            float elapsedTime = 0f;
            float originalWidth = _rectTransform.sizeDelta.x;

            while (elapsedTime < _fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float newWight = Mathf.Lerp(originalWidth, target, elapsedTime / _fadeDuration);
                _rectTransform.sizeDelta = new Vector2(newWight, _rectTransform.sizeDelta.y);
                yield return null;
            }
        }
    }
}
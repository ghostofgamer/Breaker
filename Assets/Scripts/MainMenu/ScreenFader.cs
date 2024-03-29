using System.Collections;
using UnityEngine;

namespace MainMenu
{
    [RequireComponent(typeof(RectTransform))]
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private RectTransform _rectTransform;
        private float _fadeDuration = 0.16f;
        private float _wight = 599.63f;
        private float _elapsedTime;
        private float _originalWight;

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
            _elapsedTime = 0f;
            _originalWight = _rectTransform.sizeDelta.x;

            while (_elapsedTime < _fadeDuration)
            {
                _elapsedTime += Time.deltaTime;
                float newWight = Mathf.Lerp(_originalWight, target, _elapsedTime / _fadeDuration);
                _rectTransform.sizeDelta = new Vector2(newWight, _rectTransform.sizeDelta.y);
                yield return null;
            }
        }
    }
}
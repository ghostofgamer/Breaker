using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Buttons.EndScreenButtons
{
    public class TryAgainButton : AbstractButton
    {
        [SerializeField] private UIAnimations _uiAnimations;
        [SerializeField] private Image _fadePanel;
        [SerializeField] private AudioSource _audioSource;

        private float _elapsedTime;
        private float _duration = 1f;
        private float _alphaFull = 1f;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            StartCoroutine(ReturnToMenu());
        }

        private IEnumerator ReturnToMenu()
        {
            _uiAnimations.Close();
            _elapsedTime = 0;
            Color startColor = _fadePanel.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, _alphaFull);

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                _fadePanel.color = Color.Lerp(startColor, endColor, _elapsedTime / _duration);
                yield return null;
            }

            _fadePanel.color = endColor;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
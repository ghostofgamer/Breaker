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
        private Color _startColor;
        private Color _endColor;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            StartCoroutine(ReturnToMenu());
        }

        private IEnumerator ReturnToMenu()
        {
            _uiAnimations.Close();
            _elapsedTime = 0;
            _startColor = _fadePanel.color;
            _endColor = new Color(_startColor.r, _startColor.g, _startColor.b, _alphaFull);

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                _fadePanel.color = Color.Lerp(_startColor, _endColor, _elapsedTime / _duration);
                yield return null;
            }

            _fadePanel.color = _endColor;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
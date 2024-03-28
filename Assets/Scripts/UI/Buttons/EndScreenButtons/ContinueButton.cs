using System.Collections;
using ADS;
using MainMenu;
using Statistics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.EndScreenButtons
{
    public class ContinueButton : AbstractButton
    {
        [SerializeField] private UIAnimations _uiAnimations;
        [SerializeField] private Image _fadePanel;
        [SerializeField] private FullAds _fullAds;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private BrickSmashedCounter _brickSmashedCounter;

        private float _elapsedTime;
        private float _duration = 1f;
        private float _alphaFull = 1;
        private Color _startColor;
        private Color _endColor;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _brickSmashedCounter.AddValue(_brickCounter.GetAmountSmashed());
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

#if UNITY_WEBGL && !UNITY_EDITOR
               _fullAds.Show();
#endif
        }
    }
}
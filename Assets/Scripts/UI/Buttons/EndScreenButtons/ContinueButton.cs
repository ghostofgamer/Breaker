using System.Collections;
using ADS;
using MainMenu;
using Statistics;
using UnityEngine;
using UnityEngine.SceneManagement;
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
            Color startColor = _fadePanel.color;
            Color endColor = new Color(startColor.r, startColor.g, startColor.b, _alphaFull);

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                _fadePanel.color = Color.Lerp(startColor, endColor, _elapsedTime / _duration);
                yield return null;
            }

            _fadePanel.color = endColor;

#if UNITY_WEBGL && !UNITY_EDITOR
               _fullAds.Show();
#endif

#if UNITY_EDITOR
            SceneManager.LoadScene("ChooseLvlScene");
#endif
        }
    }
}
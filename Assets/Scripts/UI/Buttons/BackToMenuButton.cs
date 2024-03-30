using System.Collections;
using Levels;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI.Buttons
{
    public class BackToMenuButton : AbstractButton
    {
        private const string NameScene = "MainScene";

        [SerializeField] private CanvasAnimator _canvasAnimator;
        [SerializeField] private ColliderToggle _colliderToggle;
        [SerializeField] private Image _fadeImage;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private float _elapsedTime;
        private float _duration = 1;
        private int _zeroAlpha = 0;
        private int _fullAlpha = 1;

        private void Start()
        {
            StartCoroutine(Fade(_fullAlpha, _zeroAlpha));
        }

        public void FadeBackGround()
        {
            StartCoroutine(Fade(_zeroAlpha, _fullAlpha));
        }

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            GoMainMenu();
        }

        private void GoMainMenu()
        {
            StartCoroutine(GoMainScene());
            StartCoroutine(Fade(_zeroAlpha, _fullAlpha));
        }

        private IEnumerator GoMainScene()
        {
            _canvasAnimator.Close();
            _colliderToggle.ColliderDeactivation();
            yield return _waitForSeconds;
            SceneManager.LoadScene(NameScene);
        }

        private IEnumerator Fade(int startAlpha, int targetAlpha)
        {
            _elapsedTime = 0;

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, targetAlpha, _elapsedTime / _duration);
                _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, alpha);
                yield return null;
            }
        }
    }
}
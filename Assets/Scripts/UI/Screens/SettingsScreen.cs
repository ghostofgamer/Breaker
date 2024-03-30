using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    [RequireComponent(typeof(CanvasGroup))]
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private UIAnimations _uiAnimations;
        [SerializeField] private SettingsScreenSound _settingsScreenSound;

        private CanvasGroup _canvasGroup;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private Coroutine _coroutine;
        private float _timePauseCloseEnd = 0.15f;
        private float _timePauseOpenEnd = 0.45f;
        private int _zeroAlpha = 0;
        private int _fullAlpha = 1;

        public bool IsOpen { get; private set; }

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            SetValue(_zeroAlpha, false);
        }

        public void Open()
        {
            IsOpen = true;
            SetValue(_fullAlpha, true);
            _uiAnimations.Open();
            _settingsScreenSound.Play(0, _timePauseOpenEnd, _audioClip, _audioSource.clip);
            Time.timeScale = 0;
        }

        public void Close()
        {
            StartCoroutine(CloseScreen());
        }

        private IEnumerator CloseScreen()
        {
            _uiAnimations.Close();
            _settingsScreenSound.Play(0, _timePauseCloseEnd, _audioSource.clip, _audioClip);
            yield return _waitForSeconds;
            IsOpen = false;
            SetValue(_zeroAlpha, false);
        }

        private void SetValue(int alpha, bool flag)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.alpha = alpha;
                _canvasGroup.interactable = flag;
                _canvasGroup.blocksRaycasts = flag;
            }
        }
    }
}
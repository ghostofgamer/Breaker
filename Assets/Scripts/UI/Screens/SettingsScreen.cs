using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private UIAnimations _uiAnimations;

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
            Setvalue(_zeroAlpha, false);
        }

        public void Open()
        {
            IsOpen = true;
            Setvalue(_fullAlpha, true);
            _uiAnimations.Open();
            Play(0, _timePauseOpenEnd, _audioClip, _audioSource.clip);
            Time.timeScale = 0;
        }

        public void Close()
        {
            StartCoroutine(CloseScreen());
        }

        private IEnumerator CloseScreen()
        {
            _uiAnimations.Close();
            Play(0, _timePauseCloseEnd, _audioSource.clip, _audioClip);
            yield return _waitForSeconds;
            IsOpen = false;
            Setvalue(_zeroAlpha, false);
        }

        private void Setvalue(int alpha, bool flag)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.alpha = alpha;
                _canvasGroup.interactable = flag;
                _canvasGroup.blocksRaycasts = flag;
            }
        }

        private void Play(float start, float end, AudioClip audioClipStart, AudioClip audioClipEnd)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(PlaySound(start, end, audioClipStart, audioClipEnd));
        }

        private IEnumerator PlaySound(float startTime, float endTime, AudioClip audioClipStart, AudioClip audioClipEnd)
        {
            yield return new WaitForSecondsRealtime(startTime);
            _audioSource.PlayOneShot(audioClipStart);
            yield return new WaitForSecondsRealtime(endTime);
            _audioSource.PlayOneShot(audioClipEnd);
        }
    }
}
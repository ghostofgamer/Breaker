using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class SettingsScreen : MonoBehaviour
    {
        // [SerializeField] private Animator _animator;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private UIAnimations _uiAnimations;
        
        private CanvasGroup _canvasGroup;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private Coroutine _coroutine;
        
        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Setvalue(0, false);
        }

        public void Open()
        {
            Setvalue(1, true);
            _uiAnimations.Open();
            // _animator.Play("Open");
            Play(0,0.45f,_audioClip,_audioSource.clip);
            Time.timeScale = 0;
        }

        public void Close()
        {
            StartCoroutine(CloseScreen());
        }

        private IEnumerator CloseScreen()
        {
            _uiAnimations.Close();
            // _animator.Play("Close");
            Play(0,0.15f,_audioSource.clip,_audioClip);
            yield return _waitForSeconds;
            Setvalue(0, false);
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

        private void Play(float start, float end,AudioClip audioClip1,AudioClip audioClip2)
        {
            if(_coroutine!=null )
                StopCoroutine(_coroutine);
            
            _coroutine = StartCoroutine(PlaySound(start,end,audioClip1,audioClip2));
        }
        
        private IEnumerator PlaySound(float startTime,float endTime, AudioClip audioClip1,AudioClip audioClip2)
        {
            yield return  new WaitForSecondsRealtime(startTime);
            _audioSource.PlayOneShot(audioClip1);
            yield return  new WaitForSecondsRealtime(endTime);
            _audioSource.PlayOneShot(audioClip2);
        }
    }
}
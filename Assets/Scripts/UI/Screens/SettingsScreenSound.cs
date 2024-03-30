using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class SettingsScreenSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private Coroutine _coroutine;
        private WaitForSecondsRealtime _waitForStart = new WaitForSecondsRealtime(0f);
        private WaitForSecondsRealtime _waitForEnd = new WaitForSecondsRealtime(0f);

        public void Play(float start, float end, AudioClip audioClipStart, AudioClip audioClipEnd)
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _waitForStart.waitTime = start;
            _waitForEnd.waitTime = end;
            _coroutine = StartCoroutine(PlaySound(start, end, audioClipStart, audioClipEnd));
        }

        private IEnumerator PlaySound(float startTime, float endTime, AudioClip audioClipStart, AudioClip audioClipEnd)
        {
            yield return _waitForStart;
            _audioSource.PlayOneShot(audioClipStart);
            yield return _waitForEnd;
            _audioSource.PlayOneShot(audioClipEnd);
        }
    }
}
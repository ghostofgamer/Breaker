using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class SettingsScreenSound : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;

        private Coroutine _coroutine;

        public void Play(float start, float end, AudioClip audioClipStart, AudioClip audioClipEnd)
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

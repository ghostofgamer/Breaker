using System.Collections;
using UnityEngine;

namespace Sound
{
    public class BackGroundSound : MonoBehaviour
    {
        [SerializeField] private float _startTime;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;

        private WaitForSeconds _waitForSeconds;
        private WaitForSeconds _waitForPause = new WaitForSeconds(1f);

        private void Start()
        {
            _waitForSeconds = new WaitForSeconds(_startTime);
            StartCoroutine(PlaySound());
        }

        private IEnumerator PlaySound()
        {
            yield return _waitForSeconds;
            _audioSource.PlayOneShot(_audioClip);
            yield return _waitForPause;
            _audioSource.Play();
        }
    }
}
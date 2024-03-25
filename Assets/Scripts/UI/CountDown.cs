using System.Collections;
using PlayerFiles.PlatformaContent;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CountDown : MonoBehaviour
    {
        private const string Play = "Play";

        [SerializeField] private TMP_Text[] _numbersText;
        [SerializeField] private PlatformaMover _platformaMover;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
        private Coroutine _coroutine;

        public void GoResume()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(Resume());
        }

        private IEnumerator Resume()
        {
            foreach (TMP_Text txt in _numbersText)
            {
                txt.gameObject.SetActive(true);
                _audioSource.PlayOneShot(_audioSource.clip);
                txt.GetComponent<Animator>().Play(Play);
                yield return _waitForSeconds;
                txt.gameObject.SetActive(false);
            }

            _platformaMover.enabled = true;
            Time.timeScale = 1;
        }
    }
}
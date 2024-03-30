using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    public class CountDown : MonoBehaviour
    {
        private const string Play = "Play";

        [SerializeField] private TMP_Text[] _numbersText;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
        private Coroutine _coroutine;
        private Animator[] _animators;

        private void Awake()
        {
            _animators = new Animator[_numbersText.Length];

            for (int i = 0; i < _numbersText.Length; i++)
                _animators[i] = _numbersText[i].GetComponent<Animator>();
        }

        public IEnumerator Resume()
        {
            for (int i = 0; i < _numbersText.Length; i++)
            {
                _numbersText[i].gameObject.SetActive(true);
                _audioSource.PlayOneShot(_audioSource.clip);
                _animators[i].Play(Play);
                yield return _waitForSeconds;
                _numbersText[i].gameObject.SetActive(false);
            }

            Time.timeScale = 1;
        }
    }
}
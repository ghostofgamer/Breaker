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

        public IEnumerator Resume()
        {
            foreach (TMP_Text numberText in _numbersText)
            {
                numberText.gameObject.SetActive(true);
                _audioSource.PlayOneShot(_audioSource.clip);
                numberText.GetComponent<Animator>().Play(Play);
                yield return _waitForSeconds;
                numberText.gameObject.SetActive(false);
            }

            Time.timeScale = 1;
        }
    }
}
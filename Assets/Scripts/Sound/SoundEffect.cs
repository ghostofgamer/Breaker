using System.Collections;
using GameScene.BallContent;
using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;

namespace Sound
{
    public class SoundEffect : MonoBehaviour
    {
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClipDiePlatform;
        [SerializeField] private AudioClip _audioClipCountDown;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private AudioSource _audioBackGroundSound;
        [SerializeField] private AudioClip _audioClipVictory;
        [SerializeField] private BrickCounter _brickCounter;

        private int _countDown = 6;
        private Coroutine _coroutine;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(2f);
        private WaitForSeconds _waitForCountDown = new WaitForSeconds(0.5f);

        private void OnEnable()
        {
            _ballTrigger.Dying += PlayDieSound;
            _reviveScreen.Lose += StopCountDown;
            _reviveScreen.Revive += StopCountDown;
            _brickCounter.AllBrickDestroy += PlayVictorySound;
        }

        private void OnDisable()
        {
            _ballTrigger.Dying -= PlayDieSound;
            _reviveScreen.Lose -= StopCountDown;
            _reviveScreen.Revive -= StopCountDown;
            _brickCounter.AllBrickDestroy -= PlayVictorySound;
        }

        public void PlayCountDownSound()
        {
            _coroutine = StartCoroutine(CountDown());
        }

        private void PlayDieSound()
        {
            _audioSource.PlayOneShot(_audioClipDiePlatform);
        }

        private void StopCountDown()
        {
            StopCoroutine(_coroutine);
        }


        private IEnumerator CountDown()
        {
            yield return _waitForSeconds;

            for (int i = 0; i < _countDown; i++)
            {
                _audioSource.PlayOneShot(_audioClipCountDown);
                yield return _waitForCountDown;
            }
        }

        private void PlayVictorySound()
        {
            if (_reviveScreen.IsLose)
                return;

            _audioBackGroundSound.enabled = false;
            _audioSource.PlayOneShot(_audioClipVictory);
        }
    }
}
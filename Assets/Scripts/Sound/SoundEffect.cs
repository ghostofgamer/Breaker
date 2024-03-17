using System;
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
        
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _ballTrigger.Dying += PlayDieSound;
            _ballTrigger.Dying +=PlayCountDownSound;
            _reviveScreen.Lose += StopCountDown;
            _reviveScreen.Revive += StopCountDown;
            _brickCounter.AllBrickDestory += PlayVictorySound;
        }

        private void OnDisable()
        {
            _ballTrigger.Dying -= PlayDieSound;
            _ballTrigger.Dying -= PlayCountDownSound;
            _reviveScreen.Lose -= StopCountDown;
            _reviveScreen.Revive -= StopCountDown;
            _brickCounter.AllBrickDestory -= PlayVictorySound;
        }

        private void PlayDieSound()
        {
            _audioSource.PlayOneShot(_audioClipDiePlatform);
        }
        
        private void PlayCountDownSound()
        {
            _coroutine =   StartCoroutine(CountDown());
        }

        private void StopCountDown()
        {
            StopCoroutine(_coroutine);
        }
        
        
        private IEnumerator CountDown()
        {
            yield return new WaitForSeconds(2f);
            
            for (int i = 0; i < 6; i++)
            {
                _audioSource.PlayOneShot(_audioClipCountDown);
                yield return new WaitForSeconds(0.5f);
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
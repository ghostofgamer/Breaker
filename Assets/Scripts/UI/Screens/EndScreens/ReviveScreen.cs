using System;
using System.Collections;
using GameScene.BallContent;
using PlayerFiles.ModificationContent;
using Sound;
using Statistics;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens.EndScreens
{
    public class ReviveScreen : EndScreen
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private BallTrigger _ball;
        [SerializeField] private UIAnimations _uiAnimationsWallet;
        [SerializeField] private BonusCounter _bonusCounter;
        [SerializeField] private LuckySave _luckySave;
        [SerializeField] private SoundEffect _soundEffect;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private float _duration = 3f;
        private float _elapsedTime;
        private Coroutine _coroutine;

        public event Action Reviving;

        public event Action Losed;

        public bool IsLose { get; private set; }

        private void OnEnable()
        {
            _ball.Dying += OnOpen;
        }

        private void OnDisable()
        {
            _ball.Dying -= OnOpen;
        }

        public override void OnOpen()
        {
            if (_luckySave.enabled)
            {
                if (_luckySave.TryGetLuckySave())
                    return;
            }

            _soundEffect.PlayCountDownSound();
            IsLose = true;
            _coroutine = StartCoroutine(EnableScreenMove());
        }

        public void ChooseRevive()
        {
            IsLose = false;
            Reviving?.Invoke();
            StopCoroutine(_coroutine);
            Close();
            _uiAnimationsWallet.Close();
        }

        public void ChooseLose()
        {
            Losed?.Invoke();
            StartCoroutine(SetActiveScreens());
        }

        private IEnumerator EnableScreenMove()
        {
            _elapsedTime = 0;
            _slider.value = 1;
            yield return _waitForSeconds;
            base.OnOpen();
            _uiAnimationsWallet.Open();
            yield return _waitForSeconds;
            float startValue = _slider.value;
            float endValue = 0;

            while (_elapsedTime < _duration)
            {
                _elapsedTime += Time.deltaTime;
                _slider.value = Mathf.Lerp(startValue, endValue, _elapsedTime / _duration);
                yield return null;
            }

            _slider.value = endValue;
            Close();
            Losed?.Invoke();
            _uiAnimationsWallet.Close();
            _bonusCounter.BringToZero();
            yield return _waitForSeconds;
            _gameOverScreen.OnOpen();
        }

        private IEnumerator SetActiveScreens()
        {
            StopCoroutine(_coroutine);
            Close();
            _uiAnimationsWallet.Close();
            _bonusCounter.BringToZero();
            yield return _waitForSeconds;
            _gameOverScreen.OnOpen();
        }
    }
}
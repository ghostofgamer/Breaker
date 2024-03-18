using System.Collections;
using GameScene.BallContent;
using Sound;
using Statistics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.Screens.EndScreens
{
    public class ReviveScreen : EndScreen
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private BallTrigger _ball;
        [SerializeField] private Animator _walletAnimator;
        [SerializeField] private BonusCounter _bonusCounter;
        [SerializeField]private LuckySave _luckySave;
        [SerializeField] private SoundEffect _soundEffect;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private float _duration = 3f;
        private float _elapsedTime;
        private Coroutine _coroutine;
        // private Animator _walletAnimator;
    
        public bool IsLose { get; private set; }

        public event UnityAction Revive; 
        public event UnityAction Lose; 
    
        private void OnEnable()
        {
            _ball.Dying += Open;
        }

        private void OnDisable()
        {
            _ball.Dying -= Open;
        }

        /*private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StopCoroutine(_coroutine);
            }
        }*/

        public override void Open()
        {
            if(_luckySave.TryGetLuckySave())
            {
                Debug.Log("оживаем");
                return;
                
            };
            _soundEffect.PlayCountDownSound();
            IsLose = true;
            _coroutine = StartCoroutine(OnScreenMove());
        }

        private IEnumerator OnScreenMove()
        {
            _elapsedTime = 0;
            _slider.value = 1;
            yield return _waitForSeconds;
            base.Open();
            _walletAnimator.Play("WalletReviveOpen");
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
            Lose?.Invoke();
            _walletAnimator.Play("WalletReviveClose");
            _bonusCounter.BringToZero();
            yield return _waitForSeconds;
            _gameOverScreen.Open();
        }

        public void ChooseRevive()
        {
            IsLose = false;
            Revive?.Invoke();
            StopCoroutine(_coroutine);
            Close();
            _walletAnimator.Play("WalletReviveClose");
        }

        public void ChooseLose()
        {
            Lose?.Invoke();
            StartCoroutine(SetActiveScreens());
        }

        private IEnumerator SetActiveScreens()
        {
            StopCoroutine(_coroutine);
            Close(); 
            _walletAnimator.Play("WalletReviveClose");
            _bonusCounter.BringToZero();
            yield return _waitForSeconds;
            _gameOverScreen.Open();
        }
    }
}
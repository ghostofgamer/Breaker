using System.Collections;
using Enum;
using Others;
using SaveAndLoad;
using Statistics;
using TMPro;
using UI.Buttons.EndScreenButtons;
using UnityEngine;

namespace UI.Screens.EndScreens
{
    public class LevelComplite : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ClaimButton _claimButton;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private SpawnBonusLevelComplete _spawnBonusLevelComplete;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private int _indexLevel;
        [SerializeField] private Save _save;
        [SerializeField] private Score _score;
        [SerializeField] private AnimationsActivator _animationsActivator;
        [SerializeField] private UIAnimations _uiAnimationsText;

        private Vector3 _target;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private Coroutine _coroutine;
        private int _factor = 30;
        private int _divider = 100;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnWin;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnWin;
        }

        private void SetValue()
        {
            gameObject.SetActive(true);
            _text.enabled = true;
        }

        private void OnWin()
        {
            Time.timeScale = 1;

            if (_reviveScreen.IsLose)
                return;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(EnableVictory());
        }

        private IEnumerator EnableVictory()
        {
            _save.SetData(Save.LevelStatus + _indexLevel, (int) LevelState.Completed);
            _save.SetData(Save.Score + _indexLevel, _scoreCounter.GetScore());
            _score.Increase(_scoreCounter.GetScore());
            SetValue();
            _uiAnimationsText.Open();
            yield return _waitForSeconds;
            _claimButton.gameObject.SetActive(true);
            _animationsActivator.PlayRotate();
            _spawnBonusLevelComplete.StartFlightBonuses();
            _claimButton.SetValue((_scoreCounter.GetScore() * _factor) / _divider);
        }
    }
}
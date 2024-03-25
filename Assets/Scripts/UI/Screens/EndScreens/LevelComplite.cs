using System.Collections;
using Enum;
using Others;
using SaveAndLoad;
using Statistics;
using TMPro;
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
        [SerializeField] private AnimationsController _animationsController;
        [SerializeField] private UIAnimations _uiAnimationsText;

        private Vector3 _target;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestory += Win;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestory -= Win;
        }

        private void SetValue()
        {
            gameObject.SetActive(true);
            _text.enabled = true;
        }

        private void Win()
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
            _animationsController.PlayRotate();
            _spawnBonusLevelComplete.StartFlightBonuses();
            _claimButton.SetValue(_scoreCounter.GetScore() * 30 / 100);
        }
    }
}
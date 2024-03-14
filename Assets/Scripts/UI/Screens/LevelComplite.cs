using System.Collections;
using Enum;
using SaveAndLoad;
using Statistics;
using TMPro;
using UI.Screens.EndScreens;
using UnityEngine;

namespace UI.Screens
{
    public class LevelComplite : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private TMP_Text _text;
        [SerializeField] private ClaimButton _claimButton;
        [SerializeField] private ScoreCounter _scoreCounter;
        [SerializeField] private SpawnBonusLevelComplite _spawnBonusLevelComplite;
        [SerializeField] private Animator _animatorEnviropment;
        [SerializeField] private Animator _animatorText;
        [SerializeField] private ReviveScreen _reviveScreen;
        [SerializeField] private int _indexLevel;
        [SerializeField] private Save _save;

        private Vector3 _target;
        private bool _isVictory = false;
        private float _speed = 100f;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private WaitForSeconds _waitForSeconds1 = new WaitForSeconds(1f);
        private Coroutine _coroutine;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestory += Victory;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestory -= Victory;
        }

        private void SetValue()
        {
            gameObject.SetActive(true);
            _text.enabled = true;
        }

        private void Victory()
        {
            Time.timeScale = 1;

            if (_reviveScreen.IsLose)
                return;

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(_OnVictory());
        }

        private IEnumerator _OnVictory()
        {
            _save.SetData("LevelStatus" + _indexLevel, (int) LevelState.Completed);
            _save.SetData(Save.Score + _indexLevel, _scoreCounter.GetScore());
            SetValue();
            _animatorText.Play("LevelCompliteTextMove");
            yield return _waitForSeconds;
            _claimButton.gameObject.SetActive(true);
            _animatorEnviropment.Play("EnviropmentRotate");
            _spawnBonusLevelComplite.StartFlightBonuses();
            /*yield return new WaitForSeconds(0.3f);
        _claimButton.SetActive();*/
            // Debug.Log("10 делим " + _scoreCounter.GetScore() / 10);
            _claimButton.SetValue(_scoreCounter.GetScore() / 10);
        }
    }
}
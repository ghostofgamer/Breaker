using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VictoryScreen : EndScreen
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private BuffCounter _buffCounter;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private FragmentsCounter _fragmentsCounter;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Animator _animator;

    [Header("StatisticTMP")] [SerializeField]
    private TMP_Text _timer;

    [SerializeField] private TMP_Text _buffCollected;
    [SerializeField] private TMP_Text _brickSmashed;
    [SerializeField] private TMP_Text _fragmentsCollected;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _creditsTxt;

    private int _credits = 0;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    /*private void OnEnable()
    {
        _brickCounter.AllBrickDestory += Open;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= Open;
    }*/

    public override void Open()
    {
        StartCoroutine(OnScreenMove());
        // SetValue();
        // Time.timeScale = 0;
        base.Open();
    }

    private void SetValue()
    {
        _buffCollected.text = _buffCounter.GetStatistic();
        _timer.text = _levelTimer.GetTime();
        _brickSmashed.text = _brickCounter.GetAmountSmashed();
        _fragmentsCollected.text = _fragmentsCounter.GetAmountFragmentsCollect();
        _score.text = _scoreCounter.GetScore().ToString();
        _credits = _scoreCounter.GetScore() / 10;
        _creditsTxt.text = _credits.ToString();
    }

    private void ScreenMover()
    {
        _animator.SetTrigger("Victory");
    }

    private IEnumerator OnScreenMove()
    {
        ScreenMover();
        yield return _waitForSeconds;
        SetValue();
    }
}
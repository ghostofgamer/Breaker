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
    [SerializeField] private GameObject[] _statistics;
    
    [Header("StatisticTMP")] [SerializeField]
    private TMP_Text _timer;

    [SerializeField] private TMP_Text _buffCollected;
    [SerializeField] private TMP_Text _brickSmashed;
    [SerializeField] private TMP_Text _fragmentsCollected;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _creditsTxt;

    private int _credits = 0;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private WaitForSeconds _waitForSecondsStatistics = new WaitForSeconds(0.365f);
    
    private void Start()
    {
        foreach (var statistic in _statistics)
        {
            statistic.SetActive(false);
        }
    }

    public override void Open()
    {
        StartCoroutine(OnScreenMove());
        base.Open();
    }

    private void SetValue()
    {
        _buffCollected.text = _buffCounter.GetStatistic();
        _timer.text = _levelTimer.GetTime();
        _brickSmashed.text = _brickCounter.GetAmountSmashed();
        _fragmentsCollected.text = _fragmentsCounter.GetAmountFragmentsCollect();
        _credits = _scoreCounter.GetScore() / 10;
        _creditsTxt.text = _credits.ToString();
    }

    private void ScreenMover()
    {
        _animator.Play("ScreenOpen");
    }

    private IEnumerator OnScreenMove()
    {
        ScreenMover();
        yield return _waitForSeconds;
        SetValue();

        for (int i = 0; i < _statistics.Length; i++)
        {
            _statistics[i].SetActive(true);

            if (i == 4)
            {
                float score = 0;
                int creditsWin = _scoreCounter.GetScore();
                float elapsedTime = 0;
                float endTime = 1;

                while (elapsedTime < endTime)
                {
                    elapsedTime += Time.deltaTime;
                    float time = elapsedTime / endTime;
                    score = (int) Mathf.Lerp(score, creditsWin, time);
                    _score.text = score.ToString();
                    yield return null;
                }
            }
            
            yield return _waitForSecondsStatistics;
        }
    }
}
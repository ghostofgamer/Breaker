using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveScreen : EndScreen
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private BallTrigger _ball;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private float _duration = 3f;
    private float _elapsedTime;
    private Coroutine _coroutine;
    public bool IsLose { get; private set; }

    private void OnEnable()
    {
        _ball.Dying += Open;
    }

    private void OnDisable()
    {
        _ball.Dying -= Open;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine(_coroutine);
        }
    }

    public override void Open()
    {
        IsLose = true;
        _coroutine = StartCoroutine(OnScreenMove());
    }

    private IEnumerator OnScreenMove()
    {
        _elapsedTime = 0;
        _slider.value = 1;
        yield return _waitForSeconds;
        base.Open();
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
        yield return _waitForSeconds;
        _gameOverScreen.Open();
    }

    public void ChooseRevive()
    {
        IsLose = false;
        StopCoroutine(_coroutine);
        Close();
    }

    public void ChooseLose()
    {
        StartCoroutine(SetActiveScreens());
    }

    private IEnumerator SetActiveScreens()
    {
        StopCoroutine(_coroutine);
        Close();
        yield return _waitForSeconds;
        _gameOverScreen.Open();
    }
}
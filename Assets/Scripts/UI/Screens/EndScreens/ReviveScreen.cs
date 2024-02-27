using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReviveScreen : EndScreen
{
    [SerializeField] private Slider _slider;
    [SerializeField] private GameOverScreen _gameOverScreen;
    [SerializeField] private Animator _animator;
    [SerializeField] private BallTrigger _ball;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private float _duration = 3f;
    private float _elapsedTime;

    private void OnEnable()
    {
        _ball.Dying += Open;
    }

    private void OnDisable()
    {
        _ball.Dying -= Open;
    }

    public override void Open()
    {
        base.Open();
        StartCoroutine(OnScreenMove());
    }

    private void ScreenMover()
    {
        _animator.Play("ScreenOpen");
    }

    private IEnumerator OnScreenMove()
    {
        ScreenMover();
        yield return _waitForSeconds;
        _elapsedTime = 0;
        float startValue = _slider.value;
        float endValue = 0;

        while (_elapsedTime<_duration)
        {
            _elapsedTime += Time.deltaTime;
            _slider.value = Mathf.Lerp(startValue,endValue,_elapsedTime/_duration);
            yield return null;
        }

        _slider.value = endValue;
    }

    private void ChangeValue()
    {
     
    }
}
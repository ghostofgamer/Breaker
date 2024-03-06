using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMenuButton : AbstractButton
{
    [SerializeField] private CanvasAnimator _canvasAnimator;
    [SerializeField] private Level[] _levels;
    [SerializeField] private Image _fadeImage;

    private const string NameScene = "MainScene";
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private float _elapsedTime;
    private float _duration = 1;

    private void Start()
    {
        StartCoroutine(Fade(1,0));
    }

    protected override void OnClick()
    {
        GoMainMenu();
    }

    private void GoMainMenu()
    {
        StartCoroutine(GoMainScene());
        StartCoroutine(Fade(0,1));
    }

    private IEnumerator GoMainScene()
    {
        _canvasAnimator.Close();

        foreach (var level in _levels)
            level.GetComponent<BoxCollider>().enabled = false;

        yield return _waitForSeconds;
        SceneManager.LoadScene(NameScene);
    }

    private IEnumerator Fade(int startAlpha, int targetAlpha)
    {
        _elapsedTime = 0;
        float startTime = 0;

        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(startAlpha, targetAlpha, _elapsedTime/_duration);
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, alpha);
            yield return null;
        }
    }
}
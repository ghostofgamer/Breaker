using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainButton : AbstractButton
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _fadePanel;
    
    private float _elapsedTime;
    private float _duration = 1f;
    
    protected override void OnClick()
    {
        StartCoroutine(ReturnToMenu());
    }

    private IEnumerator ReturnToMenu()
    {
        _animator.Play("ScreenClose");
        _elapsedTime = 0;
        Color startColor = _fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            _fadePanel.color = Color.Lerp(startColor, endColor, _elapsedTime / _duration);
            yield return null;
        }

        _fadePanel.color = endColor;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

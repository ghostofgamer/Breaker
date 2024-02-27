using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FadeStatistics : MonoBehaviour
{
    [SerializeField] private Image _backGroundImage;
    [SerializeField] private TMP_Text _textLabel;
    [SerializeField] private float _alpha;

    private float _elapsedTime;
    private float _duration = 0.365f;

    private void OnEnable()
    {
        StartCoroutine(OnFadeStatistic());
    }

    private IEnumerator OnFadeStatistic()
    {
        _elapsedTime = 0;
        Color startBackGroundColor = _backGroundImage.color;
        Color startTextColor = _textLabel.color;
        Color endBackGroundColor = new Color(startBackGroundColor.r, startBackGroundColor.g, startBackGroundColor.b, 0f);
        Color endTextColor = new Color(startTextColor.r, startTextColor.g, startTextColor.b, _alpha);

        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            _backGroundImage.color = Color.Lerp(startBackGroundColor, endBackGroundColor, _elapsedTime / _duration);
            _textLabel.color = Color.Lerp(startTextColor, endTextColor, _elapsedTime / _duration);
            yield return null;
        }

        _backGroundImage.color = endBackGroundColor;
    }
}
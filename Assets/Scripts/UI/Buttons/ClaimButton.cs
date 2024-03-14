using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI.Screens;
using UI.Screens.EndScreens;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class ClaimButton : AbstractButton
{
    [SerializeField] private LevelComplite _levelComplite;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private TMP_Text _creditsTxt;
    [SerializeField] private Image _creditIcon;
    [SerializeField] private ClaimRewardButton _claimRewardButton;
    [SerializeField] private TMP_Text _claimTxt;

    private int _credits = 0;
    private float _endTime = 1f;
    private float _elapsedTime = 0;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);

    protected override void OnClick()
    {
        _levelComplite.gameObject.SetActive(false);
        // _victoryScreen.Open();
        _victoryScreen.OpenScreen(_credits);
    }

    public void SetValue(int credits)
    {
        StartCoroutine(OnSetValue(credits));
    }

    private IEnumerator OnSetValue(int credits)
    {
        _elapsedTime = 0;
        yield return _waitForSeconds;
        _creditsTxt.enabled = true;
        _creditIcon.enabled = true;
        _claimTxt.enabled = true;
        
        while (_elapsedTime < _endTime)
        {
            _elapsedTime += Time.deltaTime;
            float time = _elapsedTime / _endTime;
            _credits = (int) Mathf.Lerp(_credits, credits, time);
            _creditsTxt.text = _credits.ToString();
            yield return null;
        }

        _credits = credits;
        _creditsTxt.text = _credits.ToString();
        _claimRewardButton.SetActive(_credits);
    }
}
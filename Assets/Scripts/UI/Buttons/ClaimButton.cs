using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;

public class ClaimButton : AbstractButton
{
    [SerializeField] private LevelComplite _levelComplite;
    [SerializeField] private VictoryScreen _victoryScreen;
    [SerializeField] private TMP_Text _creditsTxt;

    private int _credits = 0;
    private float _endTime = 1f;
    private float _elapsedTime = 0;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    
    protected override void OnClick()
    {
        _levelComplite.gameObject.SetActive(false);
        _victoryScreen.Open();
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
        
        while (_elapsedTime < _endTime)
        {
            _elapsedTime += Time.deltaTime;
            float time = _elapsedTime/_endTime;
            _credits = (int)Mathf.Lerp(_credits,credits,time);
            _creditsTxt.text = _credits.ToString();
            /*_credits = Mathf.MoveTowards(_credits, credits, 15f * Time.deltaTime);
            _creditsTxt.text = _credits.ToString("0");*/
            yield return null;
        }

        _credits = credits;
        _creditsTxt.text = _credits.ToString();
    }
}
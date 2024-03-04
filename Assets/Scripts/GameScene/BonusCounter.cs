using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _bonusTxt;

    private int _amountBonuses = 0;
    private bool _isReset;
    private float _elapsedTime;
    private float _duration = 1;

    private void Start()
    {
        ShowInfo();
    }

    public void AddBonus(int reward)
    {
        _amountBonuses += reward;
        ShowInfo();
    }

    public void GetBonus()
    {
    }

    public void BringToZero()
    {
        StartCoroutine(GoBringToZero());
    }

    private IEnumerator GoBringToZero()
    {
        _elapsedTime = 0;
        int currentBonuses = _amountBonuses;

        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            _amountBonuses = (int)Mathf.Lerp(currentBonuses, 0, _elapsedTime / _duration);
            _bonusTxt.text = _amountBonuses.ToString();
            yield return null;
        }

        _amountBonuses = 0;
        _bonusTxt.text = _amountBonuses.ToString();
    }

    private void ShowInfo()
    {
        _bonusTxt.text = _amountBonuses.ToString();
    }
}
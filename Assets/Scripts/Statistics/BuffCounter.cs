using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class BuffCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _statText;
    [SerializeField] private ScoreCounter _scoreCounter;

    private int _buffCount;
    private int _buffsCollected;
    private int _score = 15;

    public void CollectBuff()
    {
        _buffsCollected++;
        _scoreCounter.IncreaseScore(_score);
        Show();
    }

    public void IncreaseBuffCount()
    {
        _buffCount++;
        Show();
    }

    public void DecreaseBuffCount()
    {
        _buffCount--;
        Show();
    }

    public string GetStatistic()
    {
        return _buffsCollected + "/" + _buffCount;
    }

    private void Show()
    {
        string statistic = _buffsCollected + "/" + _buffCount;
        _statText.text = statistic;
    }
}
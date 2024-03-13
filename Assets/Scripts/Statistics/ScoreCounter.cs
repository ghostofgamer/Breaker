using System.Collections;
using System.Collections.Generic;
using SaveAndLoad;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BonusCounter _bonusCounter;
    [SerializeField] private Save _save;

    private int _score;

    public void IncreaseScore(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        int scoreAmount = _score + _bonusCounter.GetBonus();
        _save.SetData(Save.Score, scoreAmount);
        return scoreAmount;
    }
}
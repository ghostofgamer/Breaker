using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BonusCounter _bonusCounter;

    private int _score;

    public void IncreaseScore(int score)
    {
        _score += score;
    }

    public int GetScore()
    {
        return _score + _bonusCounter.GetBonus();
    }
}
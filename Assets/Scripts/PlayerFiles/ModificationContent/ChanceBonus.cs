using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanceBonus : MonoBehaviour
{
    private float _bonusChances = 50;
    private float _randomValue;

    public int TryIncreaseBonus(int reward)
    {
        _randomValue = Random.Range(0, 100);

        if (_randomValue > _bonusChances)
            return reward;

        reward *= 2;
        return reward;
    }
}
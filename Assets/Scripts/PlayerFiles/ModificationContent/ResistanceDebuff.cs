using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ResistanceDebuff : MonoBehaviour
{
    private float _bonusChances = 50;
    private float _randomValue;

    private void Start()
    {
    }

    public bool TryResiste()
    {
        float _randomValue = Random.Range(0, 100f);
        return _randomValue > _bonusChances;
    }
}

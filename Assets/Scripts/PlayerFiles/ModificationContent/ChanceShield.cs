using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using ModificationFiles.Buffs;
using ModificationFiles.EffectApplier;
using UnityEngine;
using Random = UnityEngine.Random;

public class ChanceShield : MonoBehaviour
{
    [SerializeField] private BallTrigger _ballTrigger;
    [SerializeField] private Shield _shield;
    
    private float _bonusChances = 16;
    private float _randomValue;

    private void OnEnable()
    {
        _ballTrigger.Bounce += TryGetShield;
    }

    private void OnDisable()
    {
        _ballTrigger.Bounce -= TryGetShield;
    }

    private void TryGetShield()
    {
        _randomValue = Random.Range(0, 100);
        Debug.Log(_randomValue);
        
        if (_randomValue > _bonusChances)
            return;
        
        _shield.ApplyModification();
        Debug.Log("НАЧАЛИ");
    }
}
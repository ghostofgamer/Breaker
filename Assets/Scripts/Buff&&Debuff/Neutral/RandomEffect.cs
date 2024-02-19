using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;


public class RandomEffect : MonoBehaviour
{
    [SerializeField] private Effect[] _effects;
    [SerializeField] protected BuffType _buffType;
    [SerializeField] private EffectApplier _effectApplier;
    [SerializeField] private DebuffApplier _debuffApplier;
    
    private BuffType randomEnumValue;
    
    public void RandomEffectActivated(PlatformaMover platformMover)
    {
        System.Random random = new System.Random();
        int choice = random.Next(0, 2);
        
        if (choice == 0)
        {
            ApplyBuff();
        }
        else
        {
            ApllyDebuff();
        }
        
        /*Array values = BuffType.GetValues(typeof(BuffType));
        int randomIndex = Random.Range(0, values.Length);
        randomEnumValue = (BuffType) values.GetValue(randomIndex);
        int value = Random.Range(0, 2);
        // value == 0 ? "ApplyBuff()" : "ApllyDebuff()";*/
    }
    
    private void ApplyBuff()
    {
        Array values = BuffType.GetValues(typeof(BuffType));
        int randomIndex = Random.Range(0, values.Length);
        randomEnumValue = (BuffType) values.GetValue(randomIndex);
        _effectApplier.Apply(randomEnumValue);
    }

    private void ApllyDebuff()
    {
        Array values = BuffType.GetValues(typeof(BuffType));
        int randomIndex = Random.Range(0, values.Length);
        randomEnumValue = (BuffType) values.GetValue(randomIndex);
        _debuffApplier.Apply(randomEnumValue);
    }
}
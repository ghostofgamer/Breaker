using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class NeutralApplier : EffectApplier
{
    [SerializeField] private RandomEffect _randomEffect;
    [SerializeField] private ResetModifications _resetModifications;
    
    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.Random:
                _randomEffect.ApplyModification();
                break;
            
            case BuffType.Reset:
                _resetModifications.ApplyModification();
                break;
        }
    }
}

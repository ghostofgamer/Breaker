using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaTrigger : MonoBehaviour
{
    [SerializeField] private BuffApplier _buffApplier;
    [SerializeField] private DebuffApplier _debuffApplier;
    [SerializeField] private NeutralApplier _neutralApplier;
    [SerializeField] private BonusCounter _bonusCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Buff buff))
            CatchEffect(_buffApplier, buff);

        if (other.TryGetComponent(out Debuff debuff))
            CatchEffect(_debuffApplier, debuff);
        
        if(other.TryGetComponent(out Neutral neutral))
            CatchEffect(_neutralApplier, neutral);

        if (other.TryGetComponent(out BonusDeath bonusDeath))
        {
            _bonusCounter.AddBonus(bonusDeath.Reward);
            bonusDeath.Die();
        }

        
    }

    public void Init(BuffApplier buffApplier,DebuffApplier debuffApplier,NeutralApplier neutralApplier)
    {
        _buffApplier = buffApplier;
        _debuffApplier = debuffApplier;
        _neutralApplier = neutralApplier;
    }
    
    private void CatchEffect(EffectApplier effectApplier, Effect effect)
    {
        effectApplier.Apply(effect.BuffType);
        effect.Destroy();
    }
}
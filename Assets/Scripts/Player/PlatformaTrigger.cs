using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaTrigger : MonoBehaviour
{
    [SerializeField] private EffectApplier _effectApplier;
    [SerializeField]private BuffApplier _buffApplier;
    [SerializeField]private DebuffApplier _debuffApplier;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Buff buff))
        {
            _buffApplier.Apply(buff.BuffType);
            buff.Destroy();
        }
        if (other.TryGetComponent(out Debuff debuff))
        {
            _debuffApplier.Apply(debuff.BuffType);
            debuff.Destroy();
        }
        
        
        
        
        
        /*if (other.TryGetComponent(out Effect effect))
        {
            _effectApplier.Apply(effect.BuffType);
            effect.Destroy();
        }*/
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaTrigger : MonoBehaviour
{
    [SerializeField] private BuffApplier _buffApplier;
    [SerializeField] private DebuffApplier _debuffApplier;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Buff buff))
            Destroy(_buffApplier, buff);

        if (other.TryGetComponent(out Debuff debuff))
            Destroy(_debuffApplier, debuff);
    }

    private void Destroy(EffectApplier effectApplier, Effect effect)
    {
        effectApplier.Apply(effect.BuffType);
        effect.Destroy();
    }
}
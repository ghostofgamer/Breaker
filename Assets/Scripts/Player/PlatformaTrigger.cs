using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaTrigger : MonoBehaviour
{
    [SerializeField] private EffectApplier effectApplier;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Effect effect))
        {
            effectApplier.Apply(effect.BuffType);
            effect.Destroy();
        }
    }
}

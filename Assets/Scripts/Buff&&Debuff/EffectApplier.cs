using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectApplier : MonoBehaviour
{
    [SerializeField] protected TestPlatformaMover TestPlatformaMover;

    public abstract void Apply(BuffType buffType);
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EffectApplier : MonoBehaviour
{
    [SerializeField] protected PlatformaMover PlatformaMover;
    [SerializeField] protected BallController  BallController;

    public abstract void Apply(BuffType buffType);
}
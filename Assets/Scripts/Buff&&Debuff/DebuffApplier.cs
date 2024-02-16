using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffApplier : EffectApplier
{
    [SerializeField] private PaddleShrinkBuff _paddleShrink;
    
    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleShrink:
                _paddleShrink.PaddleCangeValue(TestPlatformaMover);
                break;
        }
    }
}

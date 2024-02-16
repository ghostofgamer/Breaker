using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : EffectApplier
{
    [SerializeField] private PaddleGrowBuff _paddleGrow;

    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleGrow:
                _paddleGrow.PaddleCangeValue(TestPlatformaMover);
                break;
        }
    }
}

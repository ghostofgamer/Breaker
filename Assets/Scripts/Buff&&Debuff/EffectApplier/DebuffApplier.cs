using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffApplier : EffectApplier
{
    [SerializeField] private PaddleShrinkBuff _paddleShrink;
    [SerializeField] private BallShrink _ballShrink;
    
    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleShrink:
                _paddleShrink.PaddleCangeValue(PlatformaMover);
                break;
            
            case BuffType.ShrinkBall:
                _ballShrink.BallChangeSize(BallController);
                break;
        }
    }
}

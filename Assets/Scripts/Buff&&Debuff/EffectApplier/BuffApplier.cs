using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : EffectApplier
{
    [SerializeField] private PaddleGrowBuff _paddleGrow;
    [SerializeField] private BallGrow _ballGrow;
    [SerializeField]private Laser _laser;

    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleGrow:
                _paddleGrow.PaddleCangeValue(PlatformaMover);
                break;
            
            case BuffType.BallGrow:
                _ballGrow.BallChangeSize(BallController);
                break;
            case BuffType.Laser:
                _laser.Shooting(PlatformaMover);
                break;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuffApplier : EffectApplier
{
    [SerializeField] private PaddleShrinkBuff _paddleShrink;
    [SerializeField] private BallShrink _ballShrink;
    [SerializeField] private SpeedUp _speedUp;
    [SerializeField] private BallPortalMover _ballPortalMover;
    [SerializeField] private PaddleLag _paddleLag;
    [SerializeField] private Immune _immune;
    [SerializeField] private MoreBrick _moreBrick;
    
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
            
            case BuffType.SpeedUp:
                _speedUp.SpeedUpActivated(_ballPortalMover);
                break;
            
            case BuffType.PaddleLag:
                _paddleLag.PaddleLagActivated(PlatformaMover);
                break;
            
            case BuffType.Immune:
                _immune.ImmuneBricksActivated(PlatformaMover);
                break;
            
            case BuffType.MoreBrick:
                _moreBrick.MoreBricksActivated(PlatformaMover);
                break;
        }
    }
}

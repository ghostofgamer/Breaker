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
    [SerializeField] private Reverse _reverse;
    
    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleShrink:
                // _paddleShrink.PaddleCangeValue(PlatformaMover);
                _paddleShrink.ApplyModification(Player);
                break;
            
            case BuffType.ShrinkBall:
                // _ballShrink.BallChangeSize(_ballPortalMover);
                _ballShrink.ApplyModification(Player);
                break;
            
            case BuffType.SpeedUp:
                // _speedUp.SpeedUpActivated(_ballPortalMover);
                _speedUp.ApplyModification(Player);
                break;
            
            case BuffType.PaddleLag:
                // _paddleLag.PaddleLagActivated(PlatformaMover);
                _paddleLag.ApplyModification(Player);
                break;
            
            case BuffType.Immune:
                // _immune.ImmuneBricksActivated(PlatformaMover);
                _immune.ApplyModification(Player);
                break;
            
            case BuffType.MoreBrick:
                // _moreBrick.MoreBricksActivated(PlatformaMover);
                _moreBrick.ApplyModification(Player);
                break;
            
            case BuffType.Reverse:
                // _reverse.ReversePaddleActivated(PlatformaMover);
                _reverse.ApplyModification(Player);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : EffectApplier
{
    [SerializeField] private PaddleGrowBuff _paddleGrow;
    [SerializeField] private BallGrow _ballGrow;
    [SerializeField] private Laser _laser;
    [SerializeField] private Shield _shield;
    [SerializeField] private Mirror _mirror;
    [SerializeField] private Portal _portal;
    [SerializeField] private BallPortalMover _ballPortalMover;
    [SerializeField] private BonusTarget _bonusTarget;

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

            case BuffType.Shield:
                _shield.ShieldActivated(PlatformaMover);
                break;

            case BuffType.Mirror:
                _mirror.GetMirrorPlatform(PlatformaMover);
                break;

            case BuffType.Portal:
                _portal.PortalActivated(_ballPortalMover);
                break;
            
            case BuffType.BonusTarget:
                _bonusTarget.BonusTargetActivated(PlatformaMover);
                break;
        }
    }
}
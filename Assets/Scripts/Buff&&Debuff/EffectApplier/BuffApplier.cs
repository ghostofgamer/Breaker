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
                // _paddleGrow.PaddleCangeValue(PlatformaMover);
                _paddleGrow.ApplyModification(Player);
                break;

            case BuffType.BallGrow:
                // _ballGrow.BallChangeSize(_ballPortalMover);
                _ballGrow.ApplyModification(Player);
                break;

            case BuffType.Laser:
                // _laser.Shooting(PlatformaMover);
                _laser.ApplyModification(Player);
                break;

            case BuffType.Shield:
                // _shield.ShieldActivated(PlatformaMover);
                _shield.ApplyModification(Player);
                break;

            case BuffType.Mirror:
                // _mirror.GetMirrorPlatform(PlatformaMover);
                _mirror.ApplyModification(Player);
                break;

            case BuffType.Portal:
                // _portal.PortalActivated(_ballPortalMover);
                _portal.ApplyModification(Player);
                break;

            case BuffType.BonusTarget:
                // _bonusTarget.BonusTargetActivated(PlatformaMover);
                _bonusTarget.ApplyModification(Player);
                break;
        }
    }
}
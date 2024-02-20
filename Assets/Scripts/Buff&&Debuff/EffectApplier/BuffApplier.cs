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
    [SerializeField] private BonusTarget _bonusTarget;

    public override void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleGrow:
                _paddleGrow.ApplyModification();
                break;

            case BuffType.BallGrow:
                _ballGrow.ApplyModification();
                break;

            case BuffType.Laser:
                _laser.ApplyModification();
                break;

            case BuffType.Shield:
                _shield.ApplyModification();
                break;

            case BuffType.Mirror:
                _mirror.ApplyModification();
                break;

            case BuffType.Portal:
                _portal.ApplyModification();
                break;

            case BuffType.BonusTarget:
                _bonusTarget.ApplyModification();
                break;
        }
    }
}
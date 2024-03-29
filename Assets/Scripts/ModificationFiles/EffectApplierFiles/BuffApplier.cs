using Enum;
using ModificationFiles.BuffsFiles;
using UnityEngine;

namespace ModificationFiles.EffectApplierFiles
{
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
                    _paddleGrow.OnApplyModification();
                    break;

                case BuffType.BallGrow:
                    _ballGrow.OnApplyModification();
                    break;

                case BuffType.Laser:
                    _laser.OnApplyModification();
                    break;

                case BuffType.Shield:
                    _shield.OnApplyModification();
                    break;

                case BuffType.Mirror:
                    _mirror.OnApplyModification();
                    break;

                case BuffType.Portal:
                    _portal.OnApplyModification();
                    break;

                case BuffType.BonusTarget:
                    _bonusTarget.OnApplyModification();
                    break;
            }
        }
    }
}
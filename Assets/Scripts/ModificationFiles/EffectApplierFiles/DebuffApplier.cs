using Enum;
using ModificationFiles.DebuffsFiles;
using UnityEngine;

namespace ModificationFiles.EffectApplierFiles
{
    public class DebuffApplier : EffectApplier
    {
        [SerializeField] private PaddleShrinkBuff _paddleShrink;
        [SerializeField] private BallShrink _ballShrink;
        [SerializeField] private SpeedUp _speedUp;
        [SerializeField] private PaddleLag _paddleLag;
        [SerializeField] private Immune _immune;
        [SerializeField] private MoreBrick _moreBrick;
        [SerializeField] private Reverse _reverse;

        public override void Apply(BuffType buffType)
        {
            switch (buffType)
            {
                case BuffType.PaddleShrink:
                    _paddleShrink.OnApplyModification();
                    break;

                case BuffType.ShrinkBall:
                    _ballShrink.OnApplyModification();
                    break;

                case BuffType.SpeedUp:
                    _speedUp.OnApplyModification();
                    break;

                case BuffType.PaddleLag:
                    _paddleLag.OnApplyModification();
                    break;

                case BuffType.Immune:
                    _immune.OnApplyModification();
                    break;

                case BuffType.MoreBrick:
                    _moreBrick.OnApplyModification();
                    break;

                case BuffType.Reverse:
                    _reverse.OnApplyModification();
                    break;
            }
        }
    }
}
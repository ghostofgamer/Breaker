using Enum;
using ModificationFiles.Debuffs;
using UnityEngine;

namespace ModificationFiles.EffectApplier
{
    public class DebuffApplier : global::ModificationFiles.EffectApplier.EffectApplier
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
                    _paddleShrink.ApplyModification();
                    break;
            
                case BuffType.ShrinkBall:
                    _ballShrink.ApplyModification();
                    break;
            
                case BuffType.SpeedUp:
                    _speedUp.ApplyModification();
                    break;
            
                case BuffType.PaddleLag:
                    _paddleLag.ApplyModification();
                    break;
            
                case BuffType.Immune:
                    _immune.ApplyModification();
                    break;
            
                case BuffType.MoreBrick:
                    _moreBrick.ApplyModification();
                    break;
            
                case BuffType.Reverse:
                    _reverse.ApplyModification();
                    break;
            }
        }
    }
}

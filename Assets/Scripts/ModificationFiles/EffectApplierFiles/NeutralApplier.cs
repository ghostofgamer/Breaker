using Enum;
using ModificationFiles.NeutralFiles;
using UnityEngine;

namespace ModificationFiles.EffectApplierFiles
{
    public class NeutralApplier : EffectApplier
    {
        [SerializeField] private RandomEffect _randomEffect;
        [SerializeField] private ResetModifications _resetModifications;

        public override void Apply(BuffType buffType)
        {
            switch (buffType)
            {
                case BuffType.Random:
                    _randomEffect.OnApplyModification();
                    break;

                case BuffType.Reset:
                    _resetModifications.OnApplyModification();
                    break;
            }
        }
    }
}
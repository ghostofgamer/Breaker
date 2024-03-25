using Enum;
using PlayerFiles;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles.EffectApplierFiles
{
    public abstract class EffectApplier : MonoBehaviour
    {
        public abstract void Apply(BuffType buffType);
    }
}
using Enum;
using PlayerFiles;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace ModificationFiles.EffectApplier
{
    public abstract class EffectApplier : MonoBehaviour
    {
        [SerializeField] protected PlatformaMover PlatformaMover;
        [SerializeField] protected BallController  BallController;
        [SerializeField] protected  Player Player;
    
        public abstract void Apply(BuffType buffType);
    }
}
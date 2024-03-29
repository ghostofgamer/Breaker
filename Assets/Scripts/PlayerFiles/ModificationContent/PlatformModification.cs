using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class PlatformModification : MonoBehaviour
    {
        [SerializeField] private float _bonusChances = 50;

        protected float BonusChances => _bonusChances;
        
        protected int MinValue { get; private set; } = 0;
        
        protected int MaxValue { get; private set; } = 100;
    }
}
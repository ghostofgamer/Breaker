using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class PlatformModification : MonoBehaviour
    {
        [SerializeField] protected float BonusChances = 50;

        protected int MinValue = 0;
        protected int MaxValue = 100;
        protected float RandomValue;
    }
}
using GameScene.BallContent;
using ModificationFiles.Buffs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ChanceShield : PlatformModification
    {
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Shield _shield;

        private void OnEnable()
        {
            _ballTrigger.Bounce += TryGetShield;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounce -= TryGetShield;
        }

        private void TryGetShield()
        {
            RandomValue = Random.Range(MinValue, MaxValue);

            if (RandomValue > BonusChances)
                return;

            _shield.ApplyModification();
        }
    }
}
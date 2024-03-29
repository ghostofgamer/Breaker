using GameScene.BallContent;
using ModificationFiles.BuffsFiles;
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
            _ballTrigger.Bounced += OnTryGetShield;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounced -= OnTryGetShield;
        }

        private void OnTryGetShield()
        {
            RandomValue = Random.Range(MinValue, MaxValue);

            if (RandomValue > BonusChances)
                return;

            _shield.OnApplyModification();
        }
    }
}
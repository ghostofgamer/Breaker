using GameScene.BallContent;
using ModificationFiles.BuffsFiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PlayerFiles.ModificationContent
{
    public class ChanceShield : BaseModification
    {
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Shield _shield;

        private void OnEnable()
        {
            _ballTrigger.Bounced += OnAttemptShieldActivation;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounced -= OnAttemptShieldActivation;
        }

        private void OnAttemptShieldActivation()
        {
            if (Random.Range(MinValue, MaxValue) > BonusChances)
                return;

            _shield.OnApplyModification();
        }
    }
}
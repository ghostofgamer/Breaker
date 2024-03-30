using GameScene.BallContent;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class ElectricBallActivator : BaseModification
    {
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private ElectricBall _electricBall;

        private void OnEnable()
        {
            _ballTrigger.Bounced += OnBallTouch;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounced -= OnBallTouch;
        }

        private bool TryActivatedElectricEffect()
        {
            return Random.Range(MinValue, MaxValue) > BonusChances;
        }

        private void OnBallTouch()
        {
            _electricBall.gameObject.SetActive(TryActivatedElectricEffect());
        }
    }
}
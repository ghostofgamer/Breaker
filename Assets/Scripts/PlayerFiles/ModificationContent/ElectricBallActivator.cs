using GameScene.BallContent;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class ElectricBallActivator : PlatformModification
    {
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private ElectricBall _electricBall;

        private void OnEnable()
        {
            _ballTrigger.Bounce += OnSetValue;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounce -= OnSetValue;
        }

        private bool TryActivatedElectricEffect()
        {
            RandomValue = Random.Range(MinValue, MaxValue);
            return RandomValue > BonusChances;
        }

        private void OnSetValue()
        {
            _electricBall.gameObject.SetActive(TryActivatedElectricEffect());
        }
    }
}
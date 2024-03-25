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
            _ballTrigger.Bounce += TryActivatedElectricEffect;
        }

        private void OnDisable()
        {
            _ballTrigger.Bounce -= TryActivatedElectricEffect;
        }

        private void TryActivatedElectricEffect()
        {
            RandomValue = Random.Range(MinValue, MaxValue);

            if (RandomValue > BonusChances)
            {
                Activator(false);
                return;
            }

            Activator(true);
        }

        private void Activator(bool flag)
        {
            _electricBall.gameObject.SetActive(flag);
        }
    }
}
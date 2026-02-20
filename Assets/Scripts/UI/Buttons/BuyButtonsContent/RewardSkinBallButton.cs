using ADS;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class RewardSkinBallButton : AbstractButton
    {
        [SerializeField] private RewardSkinBall _rewardSkinBall;
        [SerializeField] private AudioSource _audioSource;

        protected override void OnClick()
        {
            Button.interactable = false;
            _audioSource.PlayOneShot(_audioSource.clip);
            _rewardSkinBall.Show();
        }
    }
}

using ADS;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class RewardSkinBaseButton : AbstractButton
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RewardBaseSkin _rewardBaseSkin;

        protected override void OnClick()
        {
            Button.interactable = false;
            _audioSource.PlayOneShot(_audioSource.clip);
            _rewardBaseSkin.Show();
        }
    }
}

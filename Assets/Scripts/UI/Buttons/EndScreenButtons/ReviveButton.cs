using ADS;
using UnityEngine;

namespace UI.Buttons.EndScreenButtons
{
    public class ReviveButton : AbstractButton
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RewardRevive _rewardRevive;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            Button.interactable = false;
            _rewardRevive.Show();
        }
    }
}
using ADS;
using UI.Screens.EndScreens;
using UnityEngine;

namespace UI.Buttons.EndScreenButtons
{
    public class ReviveButton : AbstractButton
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private RewardRevive _rewardRevive;
        [SerializeField] private ReviveScreen _reviveScreen;
        
        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            Button.interactable = false;
            _reviveScreen.ChooseRevive();
            _rewardRevive.Show();
        }
    }
}
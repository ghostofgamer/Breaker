using UI.Buttons.EndScreenButtons;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace ADS
{
    public class RewardTripleCredit : RewardVideo
    {
        [SerializeField] private ClaimRewardButton _claimRewardButton;
        [SerializeField] private LevelCompleteScreen _levelCompleteScreen;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private Button _button;

        protected override void OnReward()
        {
            _levelCompleteScreen.gameObject.SetActive(false);
            _victoryScreen.OpenScreen(_claimRewardButton.Credits);
        }

        protected override void OnClose()
        {
            base.OnClose();
            _button.interactable = true;
        }
    }
}
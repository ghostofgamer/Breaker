using UI.Buttons.EndScreenButtons;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace ADS
{
    public class RewardTripleCredit : RewardVideo
    {
        [SerializeField] private ClaimRewardButton _claimRewardButton;
        [SerializeField] private LevelComplite _levelComplite;
        [SerializeField] private VictoryScreen _victoryScreen;
        [SerializeField] private Button _button;

        protected override void OnReward()
        {
            _levelComplite.gameObject.SetActive(false);
            _victoryScreen.OpenScreen(_claimRewardButton.Credits);
        }

        protected override void OnClose()
        {
            base.OnClose();
            _button.interactable = true;
        }
    }
}
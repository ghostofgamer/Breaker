using UI.Buttons.EndScreenButtons;
using UI.Screens.EndScreens;
using UnityEngine;
using UnityEngine.UI;

namespace ADS
{
    [RequireComponent(typeof(Button))]
    public class RewardTripleCredit : RewardVideo
    {
        [SerializeField] private ClaimRewardButton _claimRewardButton;
        [SerializeField] private LevelComplite _levelComplite;
        [SerializeField] private VictoryScreen _victoryScreen;

        protected override void OnReward()
        {
            _levelComplite.gameObject.SetActive(false);
            _victoryScreen.OpenScreen(_claimRewardButton.Credits);
        }

        protected override void OnClose()
        {
            base.OnClose();
            _claimRewardButton.GetComponent<Button>().interactable = true;
        }
    }
}
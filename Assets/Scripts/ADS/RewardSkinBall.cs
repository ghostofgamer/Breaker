using UI.Buttons.BuyButtonsContent;
using UI.Buttons.ShopContent;
using UnityEngine;

namespace ADS
{
    public class RewardSkinBall : RewardVideo
    {
        [SerializeField] private BuySkinBallButton _buySkinBallButton;
        [SerializeField] private CloseInfoScreenButton _closeInfoButton;

        protected override void OnReward()
        {
            _buySkinBallButton.Purchase();
            _closeInfoButton.ScreenClose();
        }
    }
}

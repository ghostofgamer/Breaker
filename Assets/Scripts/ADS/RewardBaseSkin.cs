using UI.Buttons.BuyButtonsContent;
using UI.Buttons.ShopContent;
using UnityEngine;

namespace ADS
{
    public class RewardBaseSkin : RewardVideo
    {
        [SerializeField] private BuyBaseSkinButton _buyBaseSkinButton;
        [SerializeField] private CloseInfoScreenButton _closeInfoButton;

        protected override void OnReward()
        {
            _buyBaseSkinButton.Purchase();
            _closeInfoButton.ScreenClose();
        }
    }
}

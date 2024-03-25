using MainMenu.Shop.Platforms;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuyPlatformaSkinButton : BuyButton
    {
        [SerializeField] private int _index;
        [SerializeField] private PlatformaSkinShop _platformaSkinShop;

        protected override void Buy()
        {
            _platformaSkinShop.BuyCapsuleSkin(_index);
        }
    }
}
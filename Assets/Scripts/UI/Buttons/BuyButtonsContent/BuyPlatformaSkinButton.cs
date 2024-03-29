using MainMenu.Shop.Platforms;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuyPlatformaSkinButton : BuyButton
    {
        [SerializeField] private int _index;
        [SerializeField] private PlatformStore _platformStore;

        protected override void Buy()
        {
            _platformStore.BuyCapsuleSkin(_index);
        }
    }
}
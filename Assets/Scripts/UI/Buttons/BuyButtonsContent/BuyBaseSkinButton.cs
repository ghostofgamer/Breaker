using MainMenu.Shop.Platforms;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuyBaseSkinButton : BuyButton
    {
        [SerializeField] private int _index;
        [SerializeField] private BaseStore _baseStore;

        protected override void Buy()
        {
            _baseStore.BuyCapsuleSkin(_index);
        }
    }
}
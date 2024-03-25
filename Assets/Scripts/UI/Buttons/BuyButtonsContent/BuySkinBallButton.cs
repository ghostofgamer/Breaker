using Enum;
using MainMenu.Shop;
using SaveAndLoad;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuySkinBallButton : BuyButton
    {
        [SerializeField] private Skin _skin;
        [SerializeField] private BallSkins _ballSkins;
        [SerializeField] private Save _save;

        private int _purchased = 1;

        protected override void Buy()
        {
            _save.SetData(_ballSkins.ToString(), _purchased);
            Button.interactable = false;
            _skin.ChangeValue();
        }
    }
}
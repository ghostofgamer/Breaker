using Enum;
using MainMenu.Shop;
using SaveAndLoad;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuyUpgradeButton : BuyButton
    {
        [SerializeField] private Save _save;
        [SerializeField] private Buffs _buffElement;
        [SerializeField] private BuffInfo _buff;

        private int _buyValue = 3;
        
        protected override void Buy()
        {
            _save.SetData(_buffElement.ToString(), _buyValue);
            _buff.ChangeValue();
        }
    }
}
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

        protected override void Buy()
        {
            _save.SetData(_buffElement.ToString(), 3);
            _buff.ChangeValue();
        }
    }
}
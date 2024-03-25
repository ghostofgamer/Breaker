using SaveAndLoad;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Shop
{
    public class BuffInfo : MonoBehaviour
    {
        [SerializeField] private Load _load;
        [SerializeField] private Enum.Buffs _buff;
        [SerializeField] private GameObject _infoButton;
        [SerializeField] private GameObject _buyUpgradeButton;
        [SerializeField] private Image _upgradeUpLevel;
        [SerializeField] private Color _color;

        private int _startLevel = 0;

        private void Start()
        {
            int level = _load.Get(_buff.ToString(), _startLevel);

            if (level > _startLevel)
                ChangeValue();
        }

        public void ChangeValue()
        {
            _infoButton.SetActive(true);
            _buyUpgradeButton.SetActive(false);
            _upgradeUpLevel.color = _color;
        }
    }
}
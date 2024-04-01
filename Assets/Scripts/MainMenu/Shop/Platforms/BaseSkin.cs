using UnityEngine;

namespace MainMenu.Shop.Platforms
{
    public class BaseSkin : MonoBehaviour
    {
        [SerializeField] private bool _isBought;
        [SerializeField] private bool _isActive;

        public bool IsBought => _isBought;

        public bool IsActive => _isActive;

        public void EnableBought()
        {
            _isBought = true;
        }

        public void DisableBought()
        {
            _isBought = false;
        }

        public void EnableActive()
        {
            _isActive = true;
        }

        public void DisableActive()
        {
            _isActive = false;
        }
    }
}
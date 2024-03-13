using UnityEngine;

namespace MainMenu.Shop.Platforms
{
    public class PlatformaSkinData : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private bool _isBought;
        [SerializeField] private bool _isActive;

        public int Index => _index;
        public bool IsBought => _isBought;
        public bool IsActive => _isActive;

        public void SetValueBought(bool isBought)
        {
            _isBought = isBought;
        }
    
        public void SetValueActive(bool isActive)
        {
            _isActive = isActive;
        }
    }
}

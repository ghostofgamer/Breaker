using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class ShopScreen : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ShopBackGround _shopBackGround;
        [SerializeField] private CloseShopButton[] _closeShopButtons;
        [SerializeField] private Image[] _imagesActive;
        [SerializeField] private Image[] _backgroundImage;
        [SerializeField] private Color _currentColor;
        [SerializeField] private UIAnimations _uiAnimations;

        private bool _isOpen;

        public void Open()
        {
            if (!_isOpen)
            {
                _uiAnimations.Open();
                SetValue(0, 1, true);
            }
        }

        public void Close()
        {
            _uiAnimations.Close();
            SetValue(1, 0, false);
            OffImages();
        }

        private void OffImages()
        {
            foreach (Image image in _imagesActive)
                image.gameObject.SetActive(false);

            foreach (Image image in _backgroundImage)
                image.color = _currentColor;
        }

        private void SetValue(int startAlpha, int endAlpha, bool active)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _shopBackGround.BackGroundAlphaChange(startAlpha, endAlpha);

            foreach (CloseShopButton close in _closeShopButtons)
                close.gameObject.SetActive(active);

            _isOpen = active;
        }
    }
}
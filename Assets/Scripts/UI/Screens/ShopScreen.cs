using UI.Buttons.ShopContent;
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

        private int _zeroAlpha = 0;
        private int _fullAlpha = 1;

        public bool IsOpen { get; private set; }

        public void Open()
        {
            if (!IsOpen)
            {
                _uiAnimations.Open();
                SetValue(_zeroAlpha, _fullAlpha, true);
            }
        }

        public void Close()
        {
            _uiAnimations.Close();
            SetValue(_fullAlpha, _zeroAlpha, false);
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

            IsOpen = active;
        }
    }
}
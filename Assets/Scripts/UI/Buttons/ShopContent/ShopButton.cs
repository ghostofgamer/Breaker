using CameraFiles;
using Levels;
using UI.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.ShopContent
{
    public class ShopButton : AbstractButton
    {
        [SerializeField] private Image[] _imagesActive;
        [SerializeField] private int _tabIndex;
        [SerializeField] private Image[] _backgroundImage;
        [SerializeField] private Color _newColor;
        [SerializeField] private GameObject[] _tabs;
        [SerializeField] private GameObject _platformTabPc;
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private Level[] _levels;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ShopScreen _shopScreen;
        [SerializeField] private InfoLevelCloser _infoLevelCloser;
        [SerializeField] private ColliderController _colliderController;
        
        private Color _currentColor;
        private int _indexPlatformTab = 1;

        private void Start()
        {
            if (!Application.isMobilePlatform)
                _tabs[_indexPlatformTab] = _platformTabPc;

            _currentColor = _backgroundImage[_tabIndex].color;
        }

        protected override void OnClick()
        {
            if (_colliderController != null)
            {
                _colliderController.SetValue(false);
            }
            if (_infoLevelCloser != null)
                _infoLevelCloser.CloseAllScreen();

            _audioSource.PlayOneShot(_audioSource.clip);

            if (_cameraMover != null && _cameraMover.enabled)
                _cameraMover.enabled = false;

            if (_levels.Length > 0)
            {
                foreach (var level in _levels)
                    level.GetComponent<BoxCollider>().enabled = false;
            }

            _shopScreen.Open();

            ActiveImage();
            ColorChanger();
            ActiveTab();
        }

        private void ActiveImage()
        {
            foreach (Image image in _imagesActive)
                image.gameObject.SetActive(false);

            _imagesActive[_tabIndex].gameObject.SetActive(true);
        }

        private void ColorChanger()
        {
            foreach (Image image in _backgroundImage)
                image.color = _currentColor;

            _backgroundImage[_tabIndex].color = _newColor;
        }

        private void ActiveTab()
        {
            foreach (GameObject tab in _tabs)
                tab.SetActive(false);

            _tabs[_tabIndex].SetActive(true);
        }
    }
}
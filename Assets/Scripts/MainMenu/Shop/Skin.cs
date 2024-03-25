using Enum;
using SaveAndLoad;
using UI.Buttons.ShopContent;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Shop
{
    public class Skin : MonoBehaviour
    {
        [SerializeField] private GameObject _skinBlock;
        [SerializeField] private GameObject _nameToClose;
        [SerializeField] private GameObject _nameToOpen;
        [SerializeField] private InfoButton _infoButton;
        [SerializeField] private Image _locked;
        [SerializeField] private BallSkins _ballSkins;
        [SerializeField] private Load _load;

        private int _closeSkin = 0;

        private void Start()
        {
            int index = _load.Get(_ballSkins.ToString(), _closeSkin);

            if (index > _closeSkin)
                ChangeValue();
        }

        public void ChangeValue()
        {
            _skinBlock.SetActive(false);
            _infoButton.gameObject.SetActive(false);
            _locked.gameObject.SetActive(false);
            _nameToClose.SetActive(false);
            _nameToOpen.SetActive(true);
        }
    }
}
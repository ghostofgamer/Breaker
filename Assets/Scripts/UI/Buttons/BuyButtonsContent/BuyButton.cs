using PlayerFiles;
using TMPro;
using UnityEngine;

namespace UI.Buttons.BuyButtonsContent
{
    public class BuyButton : AbstractButton
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private int _price;
        [SerializeField] private CloseInfoScreenButton _closeInfoButton;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private TMP_Text _priceTxt;
        [SerializeField] private Color _color;

        protected override void OnEnable()
        {
            base.OnEnable();
            _wallet.ValueChanged += CheckSolvency;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _wallet.ValueChanged += CheckSolvency;
        }

        private void Start()
        {
            CheckSolvency();
        }

        protected override void OnClick()
        {
            if (_wallet.Money >= _price)
            {
                _audioSource.PlayOneShot(_audioSource.clip);
                Buy();
                _wallet.RemoveMoney(_price);
                _closeInfoButton.ScreenClose();
            }
            else
            {
                _audioSource.PlayOneShot(_audioClip);
            }
        }

        protected virtual void Buy() { }

        private void CheckSolvency()
        {
            if (_wallet.Money < _price)
                _priceTxt.color = _color;
        }
    }
}
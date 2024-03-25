using UI.Screens;
using UnityEngine;

namespace UI.Buttons.ShopContent
{
    public class InfoButton : AbstractButton
    {
        [SerializeField] private GameObject _screenInfo;
        [SerializeField] private ShopBackGround _shopBackGround;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UIAnimations _uiAnimations;

        private int _startAlpha = 0;
        private int _fullAlpha = 1;

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _screenInfo.SetActive(true);
            _uiAnimations.Open();
            _shopBackGround.BackGroundAlphaChange(_startAlpha, _fullAlpha);
        }
    }
}
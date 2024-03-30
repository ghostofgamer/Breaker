using MainMenu.Shop.Platforms;
using UnityEngine;

namespace UI.Buttons.ShopContent
{
    public class ActivatedBaseSkinButton : AbstractButton
    {
        [SerializeField] private BaseStore _baseStore;
        [SerializeField] private int _index;
        [SerializeField] private AudioSource _audioSource;

        protected override void OnClick()
        {
            ActivatedSkin();
        }

        private void ActivatedSkin()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _baseStore.ActivateCapsuleSkin(_index);
        }
    }
}
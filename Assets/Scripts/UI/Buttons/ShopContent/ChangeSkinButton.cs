using SaveAndLoad;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons.ShopContent
{
    public class ChangeSkinButton : AbstractButton
    {
        [SerializeField] private Image _image;
        [SerializeField] private Image _selected;
        [SerializeField] private Sprite _newSprite;
        [SerializeField] private Sprite _oldSprite;
        [SerializeField] private ChangeSkinButton[] _buttons;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;
        [SerializeField] private int _colorIndex;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] private int _index;

        private int _startSelectedIndex = 0;

        private void Start()
        {
            int indexSelected = _load.Get(Save.SelectedSkinBall, _startSelectedIndex);
            _buttons[indexSelected].ChooseSkin();
        }

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _audioSource.PlayOneShot(_audioClip);
            ChooseSkin();
        }

        private void ChooseSkin()
        {
            foreach (ChangeSkinButton button in _buttons)
                button.UnSelectedSkin();

            _image.sprite = _newSprite;
            _selected.gameObject.SetActive(true);
            _save.SetData(Save.SkinBall, _colorIndex);
            _save.SetData(Save.SelectedSkinBall, _index);
        }

        private void UnSelectedSkin()
        {
            _image.sprite = _oldSprite;
            _selected.gameObject.SetActive(false);
        }
    }
}
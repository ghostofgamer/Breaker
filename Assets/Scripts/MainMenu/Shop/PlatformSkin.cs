using Enum;
using SaveAndLoad;
using TMPro;
using UI.Buttons.ShopContent;
using UnityEngine;

namespace MainMenu.Shop
{
    public class PlatformSkin : MonoBehaviour
    {
        [SerializeField] private PlatformSkins _platformSkins;
        [SerializeField] private SelectedPlatform _selectedPlatform;
        [SerializeField] private PlatformSkin[] _platforms;
        [SerializeField] private InfoButton _infoButton;
        [SerializeField] private ActivatedButton _activatedButton;
        [SerializeField] private TMP_Text _activeTxt;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;

        private int _closeSkin = 0;
        private int _selected = 1;

        private void Start()
        {
            int index = _load.Get(_platformSkins.ToString(), _closeSkin);
            int selected = _load.Get(_selectedPlatform.ToString(), _closeSkin);

            if (index > _closeSkin)
                _infoButton.gameObject.SetActive(false);

            if (selected > _closeSkin)
                Selected();
        }

        public void ChangeValue(bool activatedButton, bool activeTxtActivation)
        {
            _activatedButton.gameObject.SetActive(activatedButton);
            _activeTxt.gameObject.SetActive(activeTxtActivation);
        }

        public void Selected()
        {
            foreach (PlatformSkin skin in _platforms)
                skin.UnSelected(true, false);
        
            ChangeValue(false, true);
            _save.SetData(_selectedPlatform.ToString(), _selected);
        }

        public void UnSelected(bool activatedButton, bool activeTxtActivation)
        {
            ChangeValue(true, false);
            _save.SetData(_selectedPlatform.ToString(), _closeSkin);
        }
    }
}
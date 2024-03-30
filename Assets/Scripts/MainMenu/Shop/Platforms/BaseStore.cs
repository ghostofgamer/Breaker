using System.Collections.Generic;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Shop.Platforms
{
    public class BaseStore : MonoBehaviour
    {
        private const string ActiveCapsuleIndex = "ActiveCapsuleIndex";
        private const string CapsuleSkinBought = "CapsuleSkinBought";
        private const string CapsuleSkinActive = "CapsuleSkinActive";

        [SerializeField] private List<BaseSkin> _platformaSkins;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;
        [SerializeField] private List<Button> _buyButtons;
        [SerializeField] private List<Button> _activateButtons;
        [SerializeField] private List<TMP_Text> _activeTexts;

        private int _activeCapsuleIndex;

        private void Start()
        {
            LoadCapsuleSkinData();
            _platformaSkins[0].EnableBought();
            _activeCapsuleIndex = _load.Get(ActiveCapsuleIndex, 0);
            _platformaSkins[_activeCapsuleIndex].EnableActive();
        }

        public void BuyCapsuleSkin(int index)
        {
            _platformaSkins[index].EnableBought();
            SaveCapsuleSkinData();
            UpdateButtons(index);
        }

        public void ActivateCapsuleSkin(int index)
        {
            if (_platformaSkins[index].IsBought)
            {
                _platformaSkins[_activeCapsuleIndex].DisableActive();
                _platformaSkins[index].EnableActive();
                _activeCapsuleIndex = index;
                _save.SetData(ActiveCapsuleIndex, _activeCapsuleIndex);
                SaveCapsuleSkinData();
                UpdateButtons(index);
            }
        }

        public void UpdateButtons(int index)
        {
            for (int i = 0; i < _platformaSkins.Count; i++)
            {
                _buyButtons[i].gameObject.SetActive(false);
                _activateButtons[i].gameObject.SetActive(false);
                _activeTexts[i].gameObject.SetActive(false);
            }

            _buyButtons[index].gameObject.SetActive(!_platformaSkins[index].IsBought);
            _activateButtons[index].gameObject
                .SetActive(_platformaSkins[index].IsBought && !_platformaSkins[index].IsActive);
            _activeTexts[index].gameObject.SetActive(_platformaSkins[index].IsActive);
        }

        private void SaveCapsuleSkinData()
        {
            for (int i = 0; i < _platformaSkins.Count; i++)
            {
                _save.SetData(CapsuleSkinBought + i, _platformaSkins[i].IsBought ? 1 : 0);
                _save.SetData(CapsuleSkinActive + i, _platformaSkins[i].IsActive ? 1 : 0);
            }
        }

        private void LoadCapsuleSkinData()
        {
            for (int i = 0; i < _platformaSkins.Count; i++)
            {
                int loadedValueBought = _load.Get(CapsuleSkinBought + i, 0);
                int loadedValueActive = _load.Get(CapsuleSkinActive + i, 0);

                if (loadedValueBought == 1)
                    _platformaSkins[i].EnableBought();
                else
                    _platformaSkins[i].DisableBought();

                if (loadedValueActive == 1)
                    _platformaSkins[i].EnableActive();
                else
                    _platformaSkins[i].DisableActive();
            }
        }
    }
}
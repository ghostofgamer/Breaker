using System.Collections.Generic;
using SaveAndLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu.Shop.Platforms
{
    public class PlatformStore : MonoBehaviour
    {
        [SerializeField] private List<PlatformaSkin> _platformaSkins;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;
        [SerializeField] private List<Button> _buyButtons;
        [SerializeField] private List<Button> _activateButtons;
        [SerializeField] private List<TMP_Text> _activeTexts;

        private int _activeCapsuleIndex;

        private void Start()
        {
            LoadCapsuleSkinData();
            _platformaSkins[0].SetValueBought(true);
            _activeCapsuleIndex = _load.Get(Save.ActiveCapsuleIndex, 0);
            _platformaSkins[_activeCapsuleIndex].SetValueActive(true);
        }

        public void BuyCapsuleSkin(int index)
        {
            _platformaSkins[index].SetValueBought(true);
            SaveCapsuleSkinData();
            UpdateButtons(index);
        }

        public void ActivateCapsuleSkin(int index)
        {
            if (_platformaSkins[index].IsBought)
            {
                _platformaSkins[_activeCapsuleIndex].SetValueActive(false);
                _platformaSkins[index].SetValueActive(true);
                _activeCapsuleIndex = index;
                _save.SetData(Save.ActiveCapsuleIndex, _activeCapsuleIndex);
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

        public void SaveCapsuleSkinData()
        {
            for (int i = 0; i < _platformaSkins.Count; i++)
            {
                _save.SetData(Save.CapsuleSkinBought + i, _platformaSkins[i].IsBought ? 1 : 0);
                _save.SetData(Save.CapsuleSkinActive + i, _platformaSkins[i].IsActive ? 1 : 0);
            }
        }

        public void LoadCapsuleSkinData()
        {
            for (int i = 0; i < _platformaSkins.Count; i++)
            {
                _platformaSkins[i].SetValueBought(_load.Get(Save.CapsuleSkinBought + i, 0) == 1);
                _platformaSkins[i].SetValueActive(_load.Get(Save.CapsuleSkinActive + i, 0) == 1);
            }
        }
    }
}
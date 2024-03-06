using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlatformaSkinShop : MonoBehaviour
{
    [SerializeField] private List<PlatformaSkinData> _platformaSkinDatas;
    [SerializeField] private Save _save;
    [SerializeField] private Load _load;

    public List<Button> buyButtons;
    public List<Button> activateButtons;
    public List<TMP_Text> activeTexts;

    private int activeCapsuleIndex;

    private void Start()
    {
        LoadCapsuleSkinData();
        _platformaSkinDatas[0].SetValueBought(true);
        activeCapsuleIndex = PlayerPrefs.GetInt("ActiveCapsuleIndex", 0);
        _platformaSkinDatas[activeCapsuleIndex].SetValueActive(true);
        // UpdateButtons();
    }

    public void BuyCapsuleSkin(int index)
    {
        _platformaSkinDatas[index].SetValueBought(true); 
        SaveCapsuleSkinData();
        UpdateButtons(index);
    }

    public void ActivateCapsuleSkin(int index)
    {
        if (_platformaSkinDatas[index].IsBought)
        {
            _platformaSkinDatas[activeCapsuleIndex].SetValueActive(false);
            _platformaSkinDatas[index].SetValueActive(true);
            activeCapsuleIndex = index;
            _save.SetData(Save.ActiveCapsuleIndex,activeCapsuleIndex);
            SaveCapsuleSkinData();
            UpdateButtons(index);
        }
    }

    public void UpdateButtons(int index)
    {
        for (int i = 0; i < _platformaSkinDatas.Count; i++)
        {
            buyButtons[i].gameObject.SetActive(false);
            activateButtons[i].gameObject.SetActive(false);
            activeTexts[i].gameObject.SetActive(false);
        }
        
        buyButtons[index].gameObject.SetActive(!_platformaSkinDatas[index].IsBought) ;
        activateButtons[index].gameObject.SetActive(_platformaSkinDatas[index].IsBought && !_platformaSkinDatas[index].IsActive) ;
        activeTexts[index].gameObject.SetActive(_platformaSkinDatas[index].IsActive);
        
        for (int i = 0; i < _platformaSkinDatas.Count; i++)
        {
            /*buyButtons[i].interactable = !_platformaSkinDatas[i].IsBought;

            // Выключаем кнопку активации, если скин не куплен или уже активен
            activateButtons[i].interactable = _platformaSkinDatas[i].IsBought && !_platformaSkinDatas[i].IsActive;

            // Если скин активен, выводим текст "Активно"
            if (_platformaSkinDatas[i].IsActive)
            {
                // Здесь вы можете добавить код для отображения текста "Активно"
            }*/
            
            
            
            
            /*if (i == activeCapsuleIndex)
            {
                buyButton.SetActive(false);
                activateButton.SetActive(false);
                activeText.SetActive(true);
            }
            else
            {
                buyButton.SetActive(!_platformaSkinDatas[i].IsBought);
                activateButton.SetActive(_platformaSkinDatas[i].IsBought);
                activeText.SetActive(false);
            }*/
        }
    }
    
    public void SaveCapsuleSkinData()
    {
        for (int i = 0; i < _platformaSkinDatas.Count; i++)
        {
            PlayerPrefs.SetInt("CapsuleSkinBought" + i, _platformaSkinDatas[i].IsBought ? 1 : 0);
            PlayerPrefs.SetInt("CapsuleSkinActive" + i, _platformaSkinDatas[i].IsActive ? 1 : 0);
        }
    }

    public void LoadCapsuleSkinData()
    {
        for (int i = 0; i < _platformaSkinDatas.Count; i++)
        {
            _platformaSkinDatas[i].SetValueBought(_load.Get("CapsuleSkinBought" + i, 0) == 1);
            _platformaSkinDatas[i].SetValueActive(_load.Get("CapsuleSkinActive" + i, 0) == 1);
        }
    }
}
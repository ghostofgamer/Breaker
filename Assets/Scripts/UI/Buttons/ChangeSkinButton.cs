using Enum;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ChangeSkinButton : AbstractButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _selected;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private Sprite _oldSprite;
    [SerializeField] private ChangeSkinButton[] _buttons;
    [SerializeField] private SelectedSkins _selectedSkin;
    [SerializeField] private Load _load;
    [SerializeField] private Save _save;
    [SerializeField] private int _startIndex;

    private int _selectedSkinIndex = 1;

    private void Start()
    {
        var index = _load.Get(_selectedSkin.ToString(), _startIndex);
        
        if (index >= _selectedSkinIndex)
        {
            ChooseSkin();
        }
    }

    protected override void OnClick()
    {
        ChooseSkin();
    }

    private void ChooseSkin()
    {
        foreach (ChangeSkinButton button in _buttons)
            button.ChangeSkin();

        _image.sprite = _newSprite;
        _selected.gameObject.SetActive(true);
        _save.SetData(_selectedSkin.ToString(), _selectedSkinIndex);
    }

    private void ChangeSkin()
    {
        _image.sprite = _oldSprite;
        _selected.gameObject.SetActive(false);
    }
}
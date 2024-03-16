using Enum;
using SaveAndLoad;
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
    [SerializeField] private int _colorIndex;
    [SerializeField]private AudioSource _audioSource;
    [SerializeField]private AudioClip _audioClip;

    private int _selectedSkinIndex = 1;
    private int _unSelectedSkinIndex = 0;

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
        _save.SetData(_selectedSkin.ToString(), _selectedSkinIndex);
        _save.SetData(Save.SkinBall,_colorIndex);
    }

    private void UnSelectedSkin()
    {
        _image.sprite = _oldSprite;
        _selected.gameObject.SetActive(false);
        _save.SetData(_selectedSkin.ToString(), _unSelectedSkinIndex);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinButton : AbstractButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private Sprite _oldSprite;
    [SerializeField] private int _index;
    [SerializeField] private ChangeSkinButton[] _buttons;

    protected override void OnClick()
    {
        foreach (ChangeSkinButton button in _buttons)
        {
            button.ChangeSkin();
        }

        _image.sprite = _newSprite;
    }

    public void ChangeSkin( )
    {
        _image.sprite = _oldSprite;
    }
}
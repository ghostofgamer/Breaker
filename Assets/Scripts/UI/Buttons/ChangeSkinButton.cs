using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinButton : AbstractButton
{
    [SerializeField] private Image _image;
    [SerializeField] private Image _accepted;
    [SerializeField] private Sprite _newSprite;
    [SerializeField] private Sprite _oldSprite;
    [SerializeField] private ChangeSkinButton[] _buttons;

    protected override void OnClick()
    {
        foreach (ChangeSkinButton button in _buttons)
        {
            button.ChangeSkin();
        }

        _image.sprite = _newSprite;
        _accepted.gameObject.SetActive(true);
    }

    public void ChangeSkin( )
    {
        _image.sprite = _oldSprite;
        _accepted.gameObject.SetActive(false);
    }
}
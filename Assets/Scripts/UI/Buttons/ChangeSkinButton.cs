using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkinButton : AbstractButton
{
    [SerializeField]private Image _image;
    [SerializeField]private Sprite _newSprite;
    [SerializeField]private Sprite _oldSprite;
    
    protected override void OnClick()
    {
        _image.sprite = _newSprite;
    }
}

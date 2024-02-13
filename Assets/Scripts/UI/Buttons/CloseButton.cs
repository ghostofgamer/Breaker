using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : AbstractButton
{
[SerializeField]private GameObject _screen;


protected override void OnClick()
{
    _screen.SetActive(false);
}
}

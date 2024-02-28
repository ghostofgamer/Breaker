using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseReviveScreen : AbstractButton
{
    [SerializeField] private ReviveScreen _reviveScreen;
    
    protected override void OnClick()
    {
        _reviveScreen.ChooseLose();
    }
}

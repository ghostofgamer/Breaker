using System.Collections;
using System.Collections.Generic;
using UI.Screens.EndScreens;
using UnityEngine;

public class CloseReviveScreen : AbstractButton
{
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField]private AudioSource     _audioSource;    
    
    protected override void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _reviveScreen.ChooseLose();
    }
}

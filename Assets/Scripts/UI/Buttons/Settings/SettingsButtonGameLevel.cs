using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using PlayerFiles.PlatformaContent;
using Statistics;
using UI.Screens;
using UI.Screens.EndScreens;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsButtonGameLevel : AbstractButton
{
    [SerializeField] private SettingsScreen _settingsScreen;
    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private BallTrigger _ball;
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField ]private AudioSource _audioSource;
    
    private void OnEnable()
    {
        base.OnEnable();
        _brickCounter.AllBrickDestory += SetValue;
        _ball.Dying += SetValue;
        _reviveScreen.Revive += SetValue;
    }

    private void OnDisable()
    {
        base.OnDisable();
        _brickCounter.AllBrickDestory -= SetValue;
        _ball.Dying -= SetValue;
        _reviveScreen.Revive -= SetValue;
    }

    protected override void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);
        _platformaMover.enabled = false;
        _platformaMover.SetPressed(false);
        _settingsScreen.Open();
    }

    private void SetValue()
    {
        Button.interactable = !Button.interactable;
    }
}
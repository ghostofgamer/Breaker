using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMoving : MonoBehaviour
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField] private Animator _animator;
    [SerializeField] private Button _button;
    
    private bool _isMove = false;

    private void OnEnable() 
    {
        _reviveScreen.Lose += PanelMover;
        _brickCounter.AllBrickDestory += PanelMover;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= PanelMover;
        _reviveScreen.Lose -= PanelMover;
    }

    private void PanelMover()
    {
        // if(_button!=null)
        //     _button.interactable = false;
        
        _animator.Play("Move");
    }

    private void GoOffScreen()
    {
        _isMove = true;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMoving : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField] private Animator _animator;

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
        Debug.Log("ваыыаыаыаыа");
        _animator.Play("BonusCounterMover");
    }
    
    private void Update()
    {
        // if (_isMove)
        //     transform.position += _direction * _speed * Time.deltaTime;
    }

    private void GoOffScreen()
    {
        _isMove = true;
    }
}
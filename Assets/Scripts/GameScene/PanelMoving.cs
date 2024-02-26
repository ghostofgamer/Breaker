using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMoving : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private BrickCounter _brickCounter;

    private bool _isMove = false;

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += GoOffScreen;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= GoOffScreen;
    }

    private void Update()
    {
        if (_isMove)
            transform.position += _direction * _speed * Time.deltaTime;
    }

    private void GoOffScreen()
    {
        _isMove = true;
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using UnityEngine;

public class MovingLevel7 : MonoBehaviour
{
    [SerializeField] private Brick[] _bricks;
    [SerializeField] private Brick[] _bricksTrigger;
    [SerializeField] private Transform _targetA;
    [SerializeField] private Transform _targetB;
    [SerializeField] private float _moveDuration = 1f;

    private Vector3 _startPosition;
    private bool _isMovingToTargetA = true;
    private float _moveTimer;

    private void OnEnable()
    {
        foreach (var brick in _bricksTrigger)
        {
            brick.Dead += ActivationPhysics;
        }
    }

    private void OnDisable()
    {
        foreach (var brick in _bricksTrigger)
        {
            brick.Dead -= ActivationPhysics;
        }
    }

    private void Start()
    {
        _startPosition = transform.position;
    }

    private void Update()
    {
        if (_moveTimer < _moveDuration)
        {
            _moveTimer += Time.deltaTime;
            float t = _moveTimer / _moveDuration;
            Vector3 targetPosition = _isMovingToTargetA ? _targetA.position : _targetB.position;
            transform.position = Vector3.Lerp(_startPosition, targetPosition, t);
        }
        else
        {
            _moveTimer = 0f;
            _isMovingToTargetA = !_isMovingToTargetA;
            _startPosition = transform.position;
        }
    }

    private void ActivationPhysics()
    {
        foreach (var brick in _bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = false;
            enabled = false;
        }
    }
}
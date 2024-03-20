using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using Unity.VisualScripting;
using UnityEngine;

public class LoopedMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _delay;
    [SerializeField] private float _corrector;
    [SerializeField] private float _distance;
    [SerializeField]private Brick[] _bricks;

    private Vector3 _targetPosition;
    private Vector3 _startPosition;
    private Rigidbody _rigidbody;
    private Coroutine _coroutine;
    
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _start;
    
    
    private void Start()
    {
        // startPosition = transform.position;
        /*_startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + _corrector);
        ;
        _targetPosition = new Vector3(_startPosition.x, _startPosition.y, _startPosition.z - _distance);*/
        _rigidbody = GetComponent<Rigidbody>();
        _coroutine =   StartCoroutine(MoveCycle());
    }

    private void OnEnable()
    {
        foreach (var brick in _bricks)
        {
            brick.Dead += SetValue;
        }
    }

    private void OnDisable()
    {
        foreach (var brick in _bricks)
        {
            brick.Dead -= SetValue;
        }
    }

    private void Update()
    {
        
    }

    private IEnumerator MoveCycle()
    {
        while (true)
        {
            // Движение к определенной позиции
            // yield return MoveToPosition(_targetPosition);
            yield return MoveToPosition(_target.position);
            yield return new WaitForSeconds(_delay);

            // Движение к стартовой позиции
            // yield return MoveToPosition(_startPosition);
            yield return MoveToPosition(_start.position);
            yield return new WaitForSeconds(_delay);
        }
    }

    private IEnumerator MoveToPosition(Vector3 destination)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
            yield return null;
        }
    }

    private void SetValue()
    {
        _rigidbody.isKinematic = false;
        StopCoroutine(_coroutine);
        enabled = false;
    }
}
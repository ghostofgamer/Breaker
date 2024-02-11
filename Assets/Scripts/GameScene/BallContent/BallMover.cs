using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class BallMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _pushForce;
    [SerializeField] private float _offsetX;
    private Rigidbody _rigidbody;

    [SerializeField] private float bounceForce;

    private bool _isActive = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!_isActive)
        {
            _isActive = true;
            _rigidbody.AddForce(new Vector3(_offsetX, _speed));


            // _rigidbody.AddForce(transform.forward * _speed, ForceMode.VelocityChange);

            /*Vector3 direction = new Vector3(Random.Range(-1f, 1f), 0, 1).normalized;
            _rigidbody.velocity = direction * _speed;
            _isActive = true;
            Debug.Log("старт   " + _rigidbody.velocity);*/
        }

        // _rigidbody.AddForce(transform.forward * _speed);
        // _rigidbody.AddForce(1,0F,_speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<PlatformController>(out var platformController))
        {
            _rigidbody.AddForce(new Vector3(_offsetX, _speed * Time.deltaTime,0f));
        }
    }

    public void Move()
    {
        _rigidbody.AddForce(new Vector3(_offsetX, _speed * Time.deltaTime,0f));
    }

    /*void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Wall>(out var wall) ||
            collision.gameObject.TryGetComponent<PlatformController>(out var platformController))
        {
            // Vector3 normal = collision.contacts[0].normal;
            _rigidbody.AddForce(new Vector3(_offsetX, _speed));
            // _rigidbody.velocity = Vector3.Reflect(_rigidbody.velocity, normal) * _pushForce;
            // Debug.Log(normal);
        }
    }*/
}
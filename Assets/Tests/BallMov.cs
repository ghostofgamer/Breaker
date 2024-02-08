using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMov : MonoBehaviour
{
    [SerializeField] private float _speed = 100f;
    private Rigidbody _rigidbody;
    private Transform reflectedObject;
    private Vector3 lastVelocity;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.velocity = transform.forward * _speed;
        // _rigidbody.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Force);
        // _rigidbody.AddForce(new Vector3(3,0,_speed* Time.deltaTime) , ForceMode.Impulse);
        // Debug.Log(_rigidbody.velocity.normalized);
        Debug.Log(transform.forward);
    }

    private void Update()
    {
        // lastVelocity = _rigidbody.velocity;
        // _rigidbody.AddForce(transform.forward * _speed * Time.deltaTime, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        Vector3 pos = Vector3.Reflect(transform.forward, other.contacts[0].normal);
        _rigidbody.velocity = pos* _speed;
Debug.Log(pos);
Debug.Log(other.contacts[0].normal);
        /*Debug.Log(lastVelocity);
        var speed = lastVelocity.magnitude;
        var direction = Vector3.Reflect(lastVelocity.normalized, other.contacts[0].normal);
_rigidbody.velocity = direction * speed;*/




        /*Vector3 normal = other.contacts[0].normal;
        Debug.Log(_rigidbody.velocity.normalized);
        Debug.Log(normal);*/

        // _rigidbody.velocity = transform.forward * _speed;
        /*
        Vector3 normal = collision.contacts[0].normal;
        Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, normal);

        // Применяем небольшое отклонение в сторону, чтобы сделать отскок более реалистичным
        float angle = Random.Range(-bounceAngle, bounceAngle);
        Debug.Log(angle);
        newDirection = Quaternion.Euler(angle, 0, angle) * newDirection;
        Debug.Log(newDirection);
        // Устанавливаем новое направление движения мяча
        rb.velocity = newDirection * speed;*/


        // reflectedObject.position = Vector3.Reflect(transform.position, Vector3.right);
        //        Debug.Log(reflectedObject.position);
    }
}
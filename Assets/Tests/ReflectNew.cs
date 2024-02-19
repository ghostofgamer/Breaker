using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class ReflectNew : MonoBehaviour
{
    
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * 30f;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.contacts[0].normal);
        // Debug.Log();
        
        float angle = UnityEngine.Random.Range(-15f, 15f);
        
        /*newDirection = Quaternion.Euler(angle, 0, angle) * newDirection;
        Debug.Log(newDirection);
        // Устанавливаем новое направление движения мяча
        rb.velocity = newDirection * speed;#1#*/
            
        Vector3 pos = Vector3.Reflect(rb.velocity.normalized, other.contacts[0].normal);
        transform.forward = pos;
        // transform.forward = Vector3.Lerp(transform.forward, pos, Time.deltaTime * 10f);
        
        Debug.Log(pos);
    }
}

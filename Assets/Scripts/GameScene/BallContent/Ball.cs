using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    /*public float speed = 5f; // Скорость движения мяча
    public float bounceAngle = 45f; // Угол отскока от стен

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Задаем начальное направление движения мяча
        rb.velocity = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Если мяч врезается в стену, меняем направление движения
        if (collision.gameObject.TryGetComponent<Wall>(out var wall))
        {
            // Вычисляем новое направление отскока
            Vector3 normal = collision.contacts[0].normal;
            Vector3 newDirection = Vector3.Reflect(rb.velocity.normalized, normal);

            // Применяем небольшое отклонение в сторону, чтобы сделать отскок более реалистичным
            float angle = Random.Range(-bounceAngle, bounceAngle);
            Debug.Log(angle);
            newDirection = Quaternion.Euler(angle, 0, angle) * newDirection;
Debug.Log(newDirection);
            // Устанавливаем новое направление движения мяча
            rb.velocity = newDirection * speed;
        }
    }*/
    
    
    
    
    
    
    
    
    public float speed = 5f; // Скорость движения мяча
    public float bounceAngle = 15f; // Угол отскока от стен

    private Vector3 direction; // Направление движения мяча

    void Start()
    {
        // Задаем начальное направление движения мяча
        direction = Vector3.forward;
    }

    void Update()
    {
        // Двигаем мяч в текущем направлении
        transform.position += direction * (speed * Time.deltaTime);
    }


    void OnCollisionEnter(Collision collision)
    {
        // Если мяч врезается в стену, меняем направление движения
        if (collision.gameObject.TryGetComponent<Wall>(out var wall)||collision.gameObject.TryGetComponent<PlatformController>(out var platformController))
        {
            Debug.Log("OnCollisionEnter2");
            // Вычисляем новое направление отскока
            Vector3 normal = collision.contacts[0].normal;
            direction = Vector3.Reflect(direction, normal);

            // Применяем небольшое отклонение в сторону, чтобы сделать отскок более реалистичным
            float angle = Random.Range(-bounceAngle, bounceAngle);
            Debug.Log(angle);
            direction = Quaternion.Euler(0, angle, 0) * direction;
            
            Debug.Log(direction);
        }
    }
}

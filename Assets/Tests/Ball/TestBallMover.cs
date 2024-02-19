using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBallMover : MonoBehaviour
{
    /*public float moveSpeed = 5f; // Скорость движения шара
    private Vector3 initialPosition;
    private Vector3 initialDirection;

    void Start()
    {
        // Сохраняем начальную позицию и направление
        initialPosition = transform.position;
        initialDirection = Quaternion.Euler(0, Random.Range(-45f, 45f), 0) * Vector3.forward;
    }

    void FixedUpdate()
    {
        // Двигаем шар по текущему направлению
        transform.Translate(initialDirection * moveSpeed * Time.fixedDeltaTime, Space.World);

        // Проверяем столкновение с границей мира
        CheckCollision();
    }

    void CheckCollision()
    {
        RaycastHit hit;

        // Луч из центра шара в текущем направлении
        if (Physics.SphereCast(transform.position, GetComponent<SphereCollider>().radius, initialDirection, out hit))
        {
            
            // Обрабатываем столкновение
            ReflectOffSurface(hit.normal, hit.collider.tag);
        }

        // Проверяем, вышел ли шар за границы
        if (IsOutOfBounds())
        {
            // Возвращаем шар к точке максимума и отталкиваем
            ReturnToMaximumPoint();
        }
    }

    void ReflectOffSurface(Vector3 normal, string tag)
    {
        // Отражаем шар от поверхности (меняем только направление по горизонтали)
        Vector3 reflectedDirection = Vector3.Reflect(initialDirection, normal);
        reflectedDirection.y = initialDirection.y; // Не меняем направление по Y
        initialDirection = reflectedDirection;

        // Если столкновение с платформой, то уменьшаем вертикальную составляющую
        if (tag == "Platform")
        {
            initialDirection.y *= 0.5f; // Пример, можно настроить в соответствии с вашими требованиями
        }
    }

    bool IsOutOfBounds()
    {
        // Проверяем, выходит ли шар за границы по X или Z
        float minX = -25f;
        float maxX = -1f;
        float minZ = -3f;
        float maxZ = 35f;

        return transform.position.x < minX || transform.position.x > maxX || transform.position.z < minZ || transform.position.z > maxZ;
    }

    void ReturnToMaximumPoint()
    {
        // Возвращаем шар к точке максимума
        float maxX = 10f;
        float maxZ = 10f;
        Vector3 maximumPoint = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, -maxZ, maxZ));
        transform.position = maximumPoint;

        // Отталкиваем шар в случайном направлении, используя Reflect
        initialDirection = Vector3.Reflect(initialDirection, Vector3.up); // Reflect относительно вертикальной оси
    }*/
    
    
    
    
    
    
    
    
    
    
    
    public float moveSpeed = 5f; // Скорость движения шара
    private Vector3 initialDirection;

    void Start()
    {
        // Задаем начальное направление движения с некоторым углом в бок
        initialDirection = Quaternion.Euler(0, UnityEngine.Random.Range(-45f, 45f), 0) * Vector3.forward;
    }

    void Update()
    {
        // Двигаем шар по начальному направлению
        transform.Translate(initialDirection * moveSpeed * Time.deltaTime, Space.World);
        
        
        
        if (IsOutOfBounds())
        {
            // Возвращаем шар к точке максимума и отталкиваем
            ReturnToMaximumPoint();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Обрабатываем столкновение с другими объектами
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Если столкнулись со стеной, отражаем шар от нее
            ReflectOffWall(collision.contacts[0].normal);
        }
        else if (collision.gameObject.CompareTag("Platform"))
        {
            // Если столкнулись с платформой, отражаем шар от нее
            ReflectOffPlatform(collision.contacts[0].normal);
        }
    }

    void ReflectOffWall(Vector3 normal)
    {
        // Отражаем шар от стены
        Vector3 reflectedDirection = Vector3.Reflect(initialDirection, normal);
        reflectedDirection.y = initialDirection.y;
        initialDirection = reflectedDirection;
    }

    void ReflectOffPlatform(Vector3 normal)
    {
        // Отражаем шар от платформы
        Vector3 reflectedDirection = Vector3.Reflect(initialDirection, normal);
        reflectedDirection.y = initialDirection.y;
        initialDirection = reflectedDirection;
    }
    
    
    bool IsOutOfBounds()
    {
        // Проверяем, выходит ли шар за границы по X или Z
        float minX = -27.16f;
        float maxX = 0f;
        float minZ = -10f;
        float maxZ = 43f;
        if (transform.position.x < minX)
        {
            Debug.Log(transform.position.x);
            Debug.Log("меньше");
        }
        if (transform.position.x > maxX)
        {
            Debug.Log("больше");
        }
        // Debug.Log("IsOutOfBounds");
        
        
        
        
        
        
        
// Debug.Log("IsOutOfBounds");
return transform.position.x < minX || transform.position.x > maxX || transform.position.z < minZ || transform.position.z > maxZ;
    }
    
    void ReturnToMaximumPoint()
    {
        /*// Возвращаем шар к точке максимума
        float maxX = 10f;
        float maxZ = 10f;
        Vector3 maximumPoint = new Vector3(Mathf.Clamp(transform.position.x, -maxX, maxX), transform.position.y, Mathf.Clamp(transform.position.z, -maxZ, maxZ));
        transform.position = maximumPoint;

        // Отталкиваем шар в случайном направлении, используя Reflect
        initialDirection = Vector3.Reflect(initialDirection, Vector3.up);*/ // Reflect относительно вертикальной оси
    }
}

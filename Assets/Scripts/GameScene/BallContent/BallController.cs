using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using PlayerFiles.PlatformaContent;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public float speed = 10.0f; // Скорость движения мяча
    public LayerMask wallLayer; // Слой, который отмечен как стены
    private Vector3 direction; // Направление движения мяча
    private float radius; // Радиус мяча

    void Start()
    {
        // Инициализируем направление движения случайным вектором
        direction = new Vector3(UnityEngine.Random.Range(-0.6f, 0.6f), 0, 1).normalized;
        // Получаем радиус сферы, которая описывает мяч
        radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
         Checkplatform();
        // Проверяем, не сталкивается ли мяч со стеной вдоль пути
        Vector3 predictedPosition = transform.position + direction * speed * Time.deltaTime;
        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit,
            (predictedPosition - transform.position).magnitude, wallLayer))
        {
            // Изменяем направление движения, отражая его от нормали точки столкновения


            direction = Vector3.Reflect(direction, hit.normal);

            // Debug.Log(" normal " + hit.normal);
            // Debug.Log(" direction " + direction);
            if (hit.collider.TryGetComponent(out BrickDestroy brickDestroy))
            {
                 // Debug.Log("попал");
                 // brickDestroy.Destroy();
            }

            if (hit.collider.TryGetComponent(out BrickExplosion brickExplosion))
            {
                // brickExplosion.Explode();
            }
               
        }
        else
        {
            // Перемещаем мяч в текущем направлении
            transform.position += direction * speed * Time.deltaTime;
        }
        
        
        // if (Physics.SphereCast(transform.position, radius, backwardDirection, out hit, maxDistance, platformLayer))
    }


    [SerializeField] private float _rayLength = 10f;
    
    public float platformOffset = 3f;

    private void Checkplatform()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Ray backray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController)||hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover testPlatformaMover)||hit.collider.gameObject.TryGetComponent<MirrorPlatformaMover>(out MirrorPlatformaMover mirrorPlatformaMover))
            {
                Debug.Log("For");
                Vector3 platformUp = hit.transform.forward; // Направление вверх платформы
                // Debug.Log("UP : " + platformUp);
                Vector3 newPosition = hit.point + platformUp * platformOffset; // Новая позиция над платформой
                // Debug.Log("Pos : " + newPosition);
                transform.position = newPosition;
                // transform.position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                // Debug.Log("Raycast hit : " + hit.collider.gameObject.name);
            }
        }

        if (Physics.Raycast(backray, out hit, _rayLength))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController)||hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover testPlatformaMover))
            {
                Debug.Log("Back");
                Vector3 platformUp = hit.transform.forward; // Направление вверх платформы
                // Debug.Log("UP : " + platformUp);
                Vector3 newPosition = hit.point + platformUp * platformOffset; // Новая позиция над платформой
                // Debug.Log("Pos : " + newPosition);
                transform.position = newPosition;
                // transform.position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                // Debug.Log("Raycast hit : " + hit.collider.gameObject.name);
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);
        Debug.DrawRay(backray.origin, backray.direction * _rayLength, Color.green);
    }

    /*private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.TryGetComponent(out BrickDestroy brickDestroy))
            Debug.Log("попал");
    }*/


    /*public float speed = 5f;
    public float bounceForce = 10f;
    public Transform platform;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveBall();
    }

    void MoveBall()
    {
        // Двигаем шар вперед без ввода пользователя
        Vector3 movement = transform.forward * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Позиция платформы в мировых координатах
        Vector3 platformPosition = platform.position;

        // Обрабатываем столкновение с платформой
        RaycastHit hit;
        float raycastLength = 1.0f; // Длина луча для рейкаста

        // Луч спереди
        if (Physics.Raycast(platformPosition + Vector3.forward * raycastLength, Vector3.back, out hit, raycastLength * 2))
        {
            if (hit.collider.TryGetComponent(out PlatformController platformController))
            {
                // Перемещаем шар, чтобы избежать столкновения с платформой
                Vector3 correction = Vector3.back * (raycastLength - hit.distance);
                rb.MovePosition(rb.position + correction);
            }
        }

        // Луч сзади
        if (Physics.Raycast(platformPosition - Vector3.forward * raycastLength, Vector3.forward, out hit, raycastLength * 2))
        {
            if (hit.collider.TryGetComponent(out PlatformController platformController))
            {
                // Перемещаем шар, чтобы избежать столкновения с платформой
                Vector3 correction = Vector3.forward * (raycastLength - hit.distance);
                rb.MovePosition(rb.position + correction);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            ReflectOffWall(collision.contacts[0].normal);
        }
        else if (collision.gameObject.TryGetComponent(out PlatformController platformController))
        {
            ReflectOffPlatform(collision.contacts[0].normal);
        }
    }

    void ReflectOffWall(Vector3 wallNormal)
    {
        // Отражаем шар от стены
        Vector3 reflection = Vector3.Reflect(rb.velocity.normalized, wallNormal);
        rb.velocity = reflection.normalized * speed;
    }

    void ReflectOffPlatform(Vector3 platformNormal)
    {
        // Отражаем шар от платформы и придаем ему дополнительную силу
        Vector3 reflection = Vector3.Reflect(rb.velocity.normalized, platformNormal);
        rb.velocity = reflection.normalized * speed;

        // Придаем шару дополнительную силу (может потребоваться настройка)
        rb.AddForce(platformNormal * bounceForce, ForceMode.Impulse);
    }*/
}

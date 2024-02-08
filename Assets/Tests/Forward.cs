using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Forward : MonoBehaviour
{
    public float speed = 10.0f; // Скорость движения мяча
    public LayerMask wallLayer; // Слой, который отмечен как стены

    private Vector3 direction; // Направление движения мяча
    private float radius; // Радиус мяча

    void Start()
    {
        // Инициализируем направление движения случайным вектором
        direction = new Vector3(Random.Range(-0.6f, 0.6f), 0, 1).normalized;
        // Получаем радиус сферы, которая описывает мяч
        radius = GetComponent<SphereCollider>().radius + 0.1f;
    }

    void Update()
    {
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
        }
        else
        {
            // Перемещаем мяч в текущем направлении
            transform.position += direction * speed * Time.deltaTime;
        }
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
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController))
            {
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
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController))
            {
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

    /*private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            Debug.Log("Raycast hit : " + hit.collider.gameObject.name);
        }
        
        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);
    }*/
}
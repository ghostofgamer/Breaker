using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBallPlatform : MonoBehaviour
{
public float speed = 10.0f; // Скорость движения мяча
    public float platformCheckRadius = 1.5f; // Дополнительный радиус для проверки столкновения с платформой
    public LayerMask platformLayer; // Слой, который отмечен как платформа
    public LayerMask wallLayer; // Слой, который отмечен как стены

    private Vector3 direction; // Направление движения мяча
    private float radius; // Радиус мяча

    void Start()
    {
        // Инициализируем направление движения случайным вектором
        direction = new Vector3(UnityEngine.Random.Range(-1f, 1f), 0, UnityEngine.Random.Range(-1f, 1f)).normalized;
        // Получаем радиус сферы, которая описывает мяч
        radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        
        
        // Проверяем, не сталкивается ли мяч с платформой вдоль пути
        Vector3 predictedPosition = transform.position + direction * speed * Time.deltaTime;
        if (Physics.SphereCast(transform.position, platformCheckRadius, direction, out RaycastHit hit, (predictedPosition - transform.position).magnitude, platformLayer))
        {
            // Изменяем направление движения, отражая его от нормали точки столкновения
            direction = Vector3.Reflect(direction, hit.normal);
Debug.Log("Й    "    +hit.distance  );
Debug.Log("в    " +platformCheckRadius);


            // Если мяч проскочил платформу, вернуть его назад и оттолкнуть от ее поверхности
            if (hit.distance > platformCheckRadius)
            {
                transform.position = hit.point - direction * radius; // Возвращаем мяч назад
                direction = Vector3.Reflect(direction, hit.normal); // Отталкиваемся от поверхности платформы
            }
        }
        else
        {
            // Проверяем, не сталкивается ли мяч со стеной вдоль пути
            if (Physics.SphereCast(transform.position, radius, direction, out hit, (predictedPosition - transform.position).magnitude, wallLayer))
            {
                // Изменяем направление движения, отражая его от нормали точки столкновения
                direction = Vector3.Reflect(direction, hit.normal);
            }
            else
            {
                // Перемещаем мяч в текущем направлении
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}

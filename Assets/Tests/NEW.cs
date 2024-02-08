using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEW : MonoBehaviour
{
    public float speed = 10.0f; // Скорость движения мяча
    public LayerMask wallLayer; // Слой, который отмечен как стены

    private Vector3 direction; // Направление движения мяча
    private float radius; // Радиус мяча

    void Start()
    {
        // Инициализируем направление движения случайным вектором
        direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        // Получаем радиус сферы, которая описывает мяч
        radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        // Проверяем, не сталкивается ли мяч со стеной вдоль пути
        Vector3 predictedPosition = transform.position + direction * speed * Time.deltaTime;
        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit, (predictedPosition - transform.position).magnitude, wallLayer))
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

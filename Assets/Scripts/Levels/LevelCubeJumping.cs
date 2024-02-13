using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCubeJumping : MonoBehaviour
{
    public float speed = 2.0f; // Скорость перемещения
    public float maxHeight = 5.0f; // Максимальная высота, до которой объект должен подниматься

    private Vector3 startPosition; // Начальная позиция объекта
    private bool movingUp = true; // Флаг направления движения

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Вычисляем новую позицию объекта
        float newY = transform.position.y + (movingUp ? 1 : -1) * speed * Time.deltaTime;

        // Проверяем, достиг ли объект максимальной высоты
        if (movingUp && newY >= startPosition.y + maxHeight)
        {
            movingUp = false; // Меняем направление движения
        }
        // Проверяем, достиг ли объект исходной высоты
        else if (!movingUp && newY <= startPosition.y)
        {
            movingUp = true; // Меняем направление движения
        }

        // Обновляем позицию объекта
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}

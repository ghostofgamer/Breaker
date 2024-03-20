using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLevel7 : MonoBehaviour
{
    public Transform targetA; // Первая целевая точка
    public Transform targetB; // Вторая целевая точка
    public float moveDuration = 1f; // Длительность движения

    private Vector3 startPosition; // Начальная позиция
    private bool isMovingToTargetA = true; // Флаг, определяющий, движется ли объект к цели A или B
    private float moveTimer; // Таймер для движения

    private void Start()
    {
        startPosition = transform.position;
        // targetB.position = startPosition;
    }

    private void Update()
    {
        
        
        
        
        
        // Если движение не завершено
        if (moveTimer < moveDuration)
        {
            moveTimer += Time.deltaTime;

            // Вычисляем фактор интерполяции (нормализованное время)
            float t = moveTimer / moveDuration;

            // Линейная интерполяция между двумя точками
            Vector3 targetPosition = isMovingToTargetA ? targetA.position : targetB.position;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
        }
        else
        {
            Debug.Log(isMovingToTargetA);
            // Движение завершено, сбрасываем таймер и меняем цель
            moveTimer = 0f;
            isMovingToTargetA = !isMovingToTargetA;
            startPosition = transform.position;
        }
    }
}

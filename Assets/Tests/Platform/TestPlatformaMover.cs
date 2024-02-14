using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlatformaMover : MonoBehaviour
{
    public float moveSpeed = 5f; // Скорость движения платформы
    public float offset = 1f; // Оффсет от точки, куда нажали мышь
    public float minX = -5f; // Минимальная позиция по оси X
    public float maxX = 5f; // Максимальная позиция по оси X
    public float minZ = -5f; // Минимальная позиция по оси Z
    public float maxZ = 5f; // Максимальная позиция по оси Z

    private bool isMousePressed = false; // Флаг, указывающий, нажата ли мышь

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Нажата левая кнопка мыши
            isMousePressed = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Отпущена левая кнопка мыши
            isMousePressed = false;
        }

        if (isMousePressed)
        {
            // Если мышь зажата, двигаем платформу в направлении указателя мыши с ограничениями
            MovePlatformWithMouse();
        }
    }

    void MovePlatformWithMouse()
    {
        // Определяем целевую позицию в мировых координатах с учетом оффсета
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z + offset);

            // Ограничиваем позицию платформы по осям X и Z
            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedZ = Mathf.Clamp(targetPosition.z, minZ, maxZ);

            // Создаем новый вектор с ограниченными значениями
            Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);

            // Двигаем платформу к целевой позиции с учетом скорости
            transform.position = Vector3.MoveTowards(transform.position, clampedTargetPosition, moveSpeed * Time.deltaTime);
        }
    }
}

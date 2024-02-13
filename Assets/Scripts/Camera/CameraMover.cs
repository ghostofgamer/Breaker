using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    /*
    public float dragSpeed = 1f;
    public float damping = 5f;
    public float minX = -5f;
    public float maxX = 13f;
    public float minZ = -35f;
    public float maxZ = 10f;
    private Vector3 dragOrigin;
    private Vector3 velocity = Vector3.zero;
    private bool isDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);

            // Применяем затухание к скорости перемещения только после отпускания кнопки мыши
            if (isDragging)
            {
                velocity = move;
            }
            else
            {
                velocity = Vector3.Lerp(velocity, Vector3.zero, damping * Time.deltaTime);
            }
        }
        else if (isDragging)
        {
            // Завершаем перетаскивание мыши
            isDragging = false;
        }

        // Перемещаем камеру на основе текущей скорости
        Vector3 newPosition = transform.position + velocity * Time.deltaTime;

        // Проверяем, не выходит ли камера за пределы ограничений
        float newX = Mathf.Clamp(newPosition.x, minX, maxX);
        float newZ = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Перемещаем камеру, если она не выходит за пределы ограничений
        transform.position = new Vector3(newX, transform.position.y, newZ);
    }
    */
    
    
    public float dragSpeed = 1;
    private Vector3 dragOrigin;
    public float minX = -3f;
    public float maxX = 13f;
    public float minZ = -30f;
    public float maxZ = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
            Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);
            // Проверяем, не выходит ли камера за пределы ограничений
            float newX = Mathf.Clamp(transform.position.x + move.x, minX, maxX);
            float newZ = Mathf.Clamp(transform.position.z + move.z, minZ, maxZ);

            // Перемещаем камеру, если она не выходит за пределы ограничений
            transform.position = new Vector3(newX, transform.position.y, newZ);
            // Debug.Log("CurentPosition " + transform.position);
        }
    }
}

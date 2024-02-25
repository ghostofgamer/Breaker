using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMover : MonoBehaviour
{
    [SerializeField] private GameObject _positionMouse;
    
    public float moveSpeed = 5f; 
    public float offset = 1f; 
    public float minX = -5f; 
    public float maxX = 5f;
    public float minZ = -5f; 
    public float maxZ = 5f; 

    private bool isMousePressed = false;
    private bool _isReverse = false;

    public float Speed => moveSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _positionMouse.SetActive(true);
            isMousePressed = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            _positionMouse.SetActive(false);
            isMousePressed = false;
        }

        if (isMousePressed)
        {
            MovePlatformWithMouse();
        }
    }

    public void SetValue(float speed)
    {
        moveSpeed = speed;
    }

    public void SetReverse(bool reverse)
    {
        _isReverse = reverse;
    }

    void MovePlatformWithMouse()
    {
        // Определяем целевую позицию в мировых координатах с учетом оффсета
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 targetPosition;

            if (_isReverse)
                targetPosition = new Vector3(-hit.point.x, transform.position.y, -(hit.point.z + offset));

            else
                targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z + offset);

            _positionMouse.transform.position = hit.point;
            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedZ = Mathf.Clamp(targetPosition.z, minZ, maxZ);

            Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);

            transform.position =
                Vector3.MoveTowards(transform.position, clampedTargetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
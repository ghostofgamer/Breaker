using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaMover : MonoBehaviour
{
    [SerializeField] private GameObject _positionMouse;
    [SerializeField] private Ball _ball;

    public float moveSpeed = 5f;
    public float offset = 1f;
    public float minX = -5f;
    public float maxX = 5f;
    public float minZ = -5f;
    public float maxZ = 5f;

    private bool isMousePressed = false;
    private bool _isReverse = false;

    public float Speed => moveSpeed;


    private Vector2 mouseDirection;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private Coroutine _coroutine;

    void Update()
    {
        float mouse = Input.GetAxis("Mouse X") * 2;
        /*Debug.Log("Mouse Direction: " + mouse);
        Debug.Log("Mouse Direction: " + new Vector3(mouse, 0, 0).normalized);*/

        /*if (Input.GetMouseButton(0))
        {
            // Получаем значения движения мыши по осям X и Y
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Сохраняем значения в Vector2
            mouseDirection = new Vector2(mouseX, mouseY);

            // Выводим значения на экран для отладки
            // Debug.Log("Mouse Direction: " + mouseDirection);
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            _positionMouse.SetActive(true);
            isMousePressed = true;
            Time.timeScale = 1;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!_ball.IsMoving)
                _ball.SetMove(true, mouse);

            _positionMouse.SetActive(false);
            isMousePressed = false;
            
            if(_coroutine!=null)
                StopCoroutine(_coroutine);
            StartCoroutine(TimeScaleChanged());
        }

        if (isMousePressed)
        {
            MovePlatformWithMouse();
        }
    }

    private IEnumerator TimeScaleChanged()
    {
        Time.timeScale = 0.35f;
        yield return _waitForSeconds;
        
        while (Time.timeScale < 1f)
            Time.timeScale += Time.deltaTime;
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


            float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
            float clampedZ = Mathf.Clamp(targetPosition.z, minZ, maxZ);

            Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);
            Vector3 targetPositiomMouse = new Vector3(hit.point.x, 4, hit.point.z);

            _positionMouse.transform.position = targetPositiomMouse;
            // _positionMouse.transform.position = hit.point;
            transform.position =
                Vector3.MoveTowards(transform.position, clampedTargetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
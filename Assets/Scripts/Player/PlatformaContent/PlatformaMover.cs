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
    private bool _isFirstThrow = true;

    public float Speed => moveSpeed;
    
    private Vector2 mouseDirection;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
    private Coroutine _coroutine;

    void Update()
    {
        float mouse = Input.GetAxis("Mouse X") * 2;

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

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            if (!_isFirstThrow)
                StartCoroutine(TimeScaleChanged());

            if (_isFirstThrow)
                _isFirstThrow = false;
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

    public void SetPressed(bool flag)
    {
        isMousePressed = flag;
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

    public void Revive()
    {
        isMousePressed = false;
        _isFirstThrow = true;
        gameObject.SetActive(true);
    }
}
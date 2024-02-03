using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _camera;

    private Rigidbody _rigidbody;
    private float _maxDistanceZ = -2f;
    private float _minDistanceZ = -0f;
    private float _DistanceX = 1.15f;

    public float yMinLimit = -2f; // Минимальный угол поворота по оси Y
    public float yMaxLimit = 0f; // Максимальный угол поворота по оси Y
    public float xMinLimit = -1f; // Минимальная позиция по оси X
    public float xMaxLimit = 1f;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            // Преобразуем экранную позицию в мировые координаты
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y,
                Camera.main.transform.position.z));

            // Ограничиваем движение платформы по осям X и Y
            float newX = Mathf.Clamp(worldPosition.x, xMinLimit, xMaxLimit);
            float newZ = Mathf.Clamp(worldPosition.z, yMinLimit, yMaxLimit);
            // float newY = Mathf.Clamp(worldPosition.y, yMinLimit, yMaxLimit);

            // Устанавливаем новую позицию платформы
            // transform.position = new Vector3(newX, newY, transform.position.z);
            Vector3 target = new Vector3(newX, transform.position.y, newZ);
            transform.position = Vector3.Lerp(transform.position, target, _speed * Time.deltaTime);
        }


        /*if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            // mousePos.z = 6;
            // mousePos.y = 6;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            Debug.Log(worldPos);
            // worldPos.y = _rigidbody.position.y;
            worldPos.z = _rigidbody.position.z;
            // worldPos.z = Mathf.Clamp(worldPos.z, _minDistanceZ, _maxDistanceZ);
            worldPos.y = Mathf.Clamp(worldPos.y, _minDistanceZ, _maxDistanceZ);
            worldPos.x = Mathf.Clamp(worldPos.x, -_DistanceX, _DistanceX);
            Vector3 targetPosition = new Vector3(worldPos.x, worldPos.y, worldPos.z);
            _rigidbody.position = Vector3.Lerp(_rigidbody.position, targetPosition, _speed * Time.deltaTime);
        }*/

        /*float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        
        // Debug.Log("H = " + mouseX);
        Debug.Log("V = " + mouseY);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(mouseX, 1, mouseY);
        _rigidbody.position = movement * _speed;*/
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<BallMover>(out var ball))
        {
            ball.Move();
        }
    }

    private void FixedUpdate()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        _rigidbody.velocity = movement * _speed;
        
        Debug.Log("H = " + moveHorizontal);*/
    }
}
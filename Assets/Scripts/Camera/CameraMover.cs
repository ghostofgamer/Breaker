using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private float _sensitivity;
    [SerializeField] private float _speed;
    [SerializeField] private float _overSpeed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minZ;
    [SerializeField] private float _maxZ;

    private Vector3 _mouseStartPos;
    private Vector3 _cameraStartPos;
    private Vector3 _newCameraPos;

    private void Start()
    {
        _mouseStartPos = Input.mousePosition;
        _cameraStartPos = transform.position;
        _newCameraPos = _cameraStartPos;
    }

    void Update()
    {
        if (transform.position != _newCameraPos)
        {
            Debug.Log(transform.position + "   ...   " + _newCameraPos);
            transform.position = Vector3.MoveTowards(transform.position, _newCameraPos, _overSpeed * Time.deltaTime);
        }


        if (Input.GetMouseButtonDown(0))
        {
            _mouseStartPos = Input.mousePosition;
            _cameraStartPos = transform.position;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 mouseDelta = Input.mousePosition - _mouseStartPos;
            Vector3 cameraDelta = new Vector3(mouseDelta.x, 0, mouseDelta.y) * _sensitivity;
            _newCameraPos = _cameraStartPos - cameraDelta;
            _newCameraPos.x = Mathf.Clamp(_newCameraPos.x, _minX, _maxX);
            _newCameraPos.z = Mathf.Clamp(_newCameraPos.z, _minZ, _maxZ);
            transform.position = Vector3.Lerp(transform.position, _newCameraPos, _speed * Time.deltaTime);
        }
    }


    //
    // public float dragSpeed = 1;
    // private Vector3 dragOrigin;
    // public float minX = -3f;
    // public float maxX = 13f;
    // public float minZ = -30f;
    // public float maxZ = 10f;
    //
    // void Update()
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         dragOrigin = Input.mousePosition;
    //     }
    //
    //     if (Input.GetMouseButton(0))
    //     {
    //         Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
    //         Vector3 move = new Vector3(-pos.x * dragSpeed, 0, -pos.y * dragSpeed);
    //         // Проверяем, не выходит ли камера за пределы ограничений
    //         float newX = Mathf.Clamp(transform.position.x + move.x, minX, maxX);
    //         float newZ = Mathf.Clamp(transform.position.z + move.z, minZ, maxZ);
    //
    //         // Перемещаем камеру, если она не выходит за пределы ограничений
    //         transform.position = new Vector3(newX, transform.position.y, newZ);
    //         // Debug.Log("CurentPosition " + transform.position);
    //     }
    // }
}
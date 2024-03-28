using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

public class PlatformFollower : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float sensitivity = 3.0f; // Чувствительность мыши
    [SerializeField] private float minRotationZ = -45.0f; // Минимальный угол поворота по оси Z
    [SerializeField] private float maxRotationZ = 45.0f; // Максимальный угол поворота по оси Z
    [SerializeField] private float _maxRotationY; // Максимальный угол поворота по оси Z
    [SerializeField] private float _minRotationY; // Максимальный угол поворота по оси Z
    [SerializeField] private float _speedRotation; // Максимальный угол поворота по оси Z

    private Vector3 rotation;
    private Vector3 _position;
    private Vector3 targetRotation;
    private bool _isWork = false;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    void Start()
    {
        rotation = transform.eulerAngles;
        targetRotation = rotation;
        _position = transform.position;
        StartCoroutine(SetActive());
    }

    void Update()
    {
        if (!_isWork)
            return;

        if (Input.GetMouseButton(0) && _platformaMover.IsAlive && _platformaMover.DirectionX != 0)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            // targetRotation.z += mouseX;
            targetRotation.y += -mouseX;
            _position.x += mouseX;

            // targetRotation.z = Mathf.Clamp(targetRotation.z, 0, 0);
            targetRotation.y = Mathf.Clamp( targetRotation.y, _minRotationY, _maxRotationY);
            _position.x = Mathf.Clamp(  _position.x, _minRotationY, _maxRotationY);
            
            transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _speedRotation);
            rotation = Vector3.Lerp(rotation, targetRotation, Time.deltaTime * _speedRotation);

            transform.eulerAngles = rotation;
        }
    }

    private IEnumerator SetActive()
    {
        yield return _waitForSeconds;
        _animator.enabled = false;
        _isWork = true;
    }


// Значение direction от 1 до -1
    // Максимальный угол поворота

    /*private void Update()
    {
        float targetRotationZ = transform.eulerAngles.z + _platformaMover.DirectionX * _speed * Time.deltaTime;
        Debug.Log("targetRotationZ " + targetRotationZ);
        Debug.Log("transform.eulerAngles.z " + transform.eulerAngles.z);
        Debug.Log("_platformaMover.DirectionX " + _platformaMover.DirectionX);
        targetRotationZ = Mathf.Clamp(targetRotationZ, -1, 1);

        Quaternion targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, targetRotationZ);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 30 * Time.deltaTime);
        ;
    }*/


    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private float _speed;

    /*private void Update()
    {
        // float clampedDirectionX = Mathf.Clamp(_platformaMover.DirectionX, -1f, 1f);
        transform.Rotate(0, 0, _platformaMover.DirectionX * _speed * Time.deltaTime);
  
        
        
        
        
        // transform.localRotation = Quaternion.Euler(transform.rotation.x,transform.rotation.y, Mathf.Clamp(transform.rotation.z,-1,1));

        //
        // if (transform.rotation.z > 1f)
        //     transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, 1f);
        //
        // if (transform.rotation.z < -1f)
        //     transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, -1f);


        /*
        float currentRotationZ = transform.eulerAngles.z;
        if (currentRotationZ > 1f)
        {
            currentRotationZ = 1f;
        }
        else if (currentRotationZ < -1f)
        {
            currentRotationZ = -1f;
        }#1#
    }*/


    /*public Transform platform;
    public float rotationSensitivity = 3f;
    public float interpolationSpeed = 10f;

    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector3 platformDirection = platform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(platformDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSensitivity * Time.deltaTime);

        Vector3 currentPosition = transform.position;
        Vector3 newPosition = Vector3.Lerp(previousPosition, currentPosition, interpolationSpeed * Time.deltaTime);
        transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);

        previousPosition = newPosition;
    }*/


    /*
    public Transform platform;
    public float rotationSensitivity = 3f;

    private Vector3 previousPlatformPosition;

    void Start()
    {
        previousPlatformPosition = _platformaMover.transform.position;
    }

    void Update()
    {
        Vector3 platformPositionDelta = _platformaMover.transform.position - previousPlatformPosition;
        previousPlatformPosition = _platformaMover.transform.position;

        float rotationAmount = platformPositionDelta.magnitude * rotationSensitivity;
        Debug.Log(rotationAmount);
        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }*/
}
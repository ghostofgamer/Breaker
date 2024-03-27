using PlayerFiles.PlatformaContent;
using UnityEngine;

public class PlatformFollower : MonoBehaviour
{
    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.Rotate(0, _platformaMover.DirectionX * _speed * Time.deltaTime, 0);
    }


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
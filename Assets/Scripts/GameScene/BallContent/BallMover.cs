using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMover : MonoBehaviour
{
    [SerializeField] private PortalTeleporterBall _portalTeleporterBall;
    [SerializeField] private float _xMinPosition;
    [SerializeField] private float _xMaxPosition;
    [SerializeField] private float _zMaxPosition;
    [SerializeField] private float _zMinPosition;
    [SerializeField] private bool _isPortal = false;
    // [SerializeField] private 

    public float speed = 10.0f;
    public LayerMask wallLayer;
    private Vector3 _direction;
    public float _radius;

    public float Speed => speed;


    void Start()
    {
        _direction = new Vector3(UnityEngine.Random.Range(-0.6f, 0.6f), 0, 1).normalized;
        _radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
        Checkplatform();
        Vector3 predictedPosition = transform.position + _direction * speed * Time.deltaTime;

        if (Physics.SphereCast(transform.position, _radius, _direction, out RaycastHit hit,
            (predictedPosition - transform.position).magnitude, wallLayer))
        {
            _direction = Vector3.Reflect(_direction, hit.normal);
        }
        else
        {
            if (_isPortal)
                _portalTeleporterBall.TeleportBall();

            /*else
                CheckBehindWall();*/

            transform.position += _direction * speed * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Brick brick))
        {
            _direction = Vector3.Reflect(_direction, other.GetContact(0).normal);
            brick.Die();
        }
    }

    public void SetValue(float speed)
    {
        this.speed = speed;
    }

    [SerializeField] private float _rayLength = 10f;

    public float platformOffset = 3f;

    private void Checkplatform()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Ray backray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _rayLength))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController) ||
                hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover testPlatformaMover) ||
                hit.collider.gameObject.TryGetComponent<MirrorPlatformaMover>(
                    out MirrorPlatformaMover mirrorPlatformaMover))
            {
                Vector3 platformUp = hit.transform.forward; // Направление вверх платформы
                Vector3 newPosition = hit.point + platformUp * platformOffset; // Новая позиция над платформой
                transform.position = newPosition;
                _direction = Vector3.Reflect(_direction, hit.normal);
            }
        }

        if (Physics.Raycast(backray, out hit, _rayLength))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformController>(out var platformController) ||
                hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover testPlatformaMover))
            {
                Debug.Log("Back");
                Vector3 platformUp = hit.transform.forward; // Направление вверх платформы
                Vector3 newPosition = hit.point + platformUp * platformOffset; // Новая позиция над платформой
                transform.position = newPosition;
                _direction = Vector3.Reflect(_direction, hit.normal);
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);
        Debug.DrawRay(backray.origin, backray.direction * _rayLength, Color.green);
    }

    // private void CheckBehindWall()
    // {
    //     Vector3 predictedPosition = transform.position + direction * speed * Time.deltaTime;
    //
    //     if (transform.position.x > _xMaxPosition)
    //     {
    //         transform.position = new Vector3(_xMaxPosition, transform.position.y, transform.position.z);
    //
    //         if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit,
    //             (predictedPosition - transform.position).magnitude, wallLayer))
    //         {
    //             direction = Vector3.Reflect(direction, hit.normal);
    //             Debug.Log("УшелВБольше");
    //         }
    //     }
    //
    //     if (transform.position.x < _xMinPosition)
    //     {
    //         transform.position = new Vector3(_xMinPosition, transform.position.y, transform.position.z);
    //
    //         if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit,
    //             (predictedPosition - transform.position).magnitude, wallLayer))
    //         {
    //             direction = Vector3.Reflect(direction, hit.normal);
    //             Debug.Log("УшелВМеньше");
    //         }
    //     }
    // }

    public void SetValue(bool portalActivated)
    {
        _isPortal = portalActivated;
    }
}
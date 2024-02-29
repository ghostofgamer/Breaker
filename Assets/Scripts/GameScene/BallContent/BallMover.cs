using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallMover : MonoBehaviour
{
    [SerializeField] private PortalTeleporterBall _portalTeleporterBall;
    [SerializeField] private float _xMinPosition;
    [SerializeField] private float _xMaxPosition;
    [SerializeField] private float _zMaxPosition;
    [SerializeField] private float _zMinPosition;
    [SerializeField] private bool _isPortal = false;
    [SerializeField] private BallTrigger _ballTrigger;

    private float _maxSpeed = 30f;
    private float _ultraSpeed = 60f;

    public float speed = 10.0f;
    public LayerMask wallLayer;
    private Vector3 _direction;
    public float _radius;

    public float Speed => speed;
    public Vector3 Direction => _direction;

    void Start()
    {
        // _direction = new Vector3(UnityEngine.Random.Range(-0.6f, 0.6f), 0, 1).normalized;
        // _direction = new Vector3(1f, 0, 0).normalized;
        // _direction = new Vector3(Input.GetAxis("Mouse X"), 0, 1);
        /*Debug.Log("StartDirection " + _direction);
        Debug.Log("MouseX " + Input.GetAxis("Mouse X"));*/
        _radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        // Debug.Log("Скорость " + speed);
        if (speed > _maxSpeed)
        {
            speed = Mathf.MoveTowards(speed, _maxSpeed, 6f * Time.deltaTime);
            // Debug.Log("Скорость " + speed);
        }


        transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
        // _ballTrigger.Checkplatform();
        _ballTrigger.CheckPlatformCollision();
        Vector3 predictedPosition = transform.position + _direction * speed * Time.deltaTime;

        if (Physics.SphereCast(transform.position, _radius, _direction, out RaycastHit hit,
            (predictedPosition - transform.position).magnitude, wallLayer))
        {
            // _direction = Vector3.Reflect(_direction, hit.normal);

            _direction = Vector3.Reflect(_direction, hit.normal);
            // Vector3
            Debug.Log(_direction);

            if (_direction.z == 0)
            {
                Debug.Log("ZERO " + _direction.z);
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.5f, 0.5f))
                    .normalized;
            }

            if (_direction.z < 0 && _direction.z > -0.3)
            {
                Debug.Log("DIREC " + _direction.z);
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.3f, -0.5f))
                    .normalized;
            }

            if (_direction.z > 0 && _direction.z < 0.3)
            {
                Debug.Log("DIREC БОЛЬШЕ " + _direction.z);
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(0.3f, 0.5f))
                    .normalized;
            }

            // Debug.Log("Hit Normal " + hit.normal);
            // Debug.Log("NewDirection " + _direction);
        }
        else
        {
            if (_isPortal)
                _portalTeleporterBall.TeleportBall();

            else
                CheckBehindWall();

            transform.position += _direction * speed * Time.deltaTime;
        }
    }

    public void SetStartDirection(Vector3 direction)
    {
        _direction = direction;
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
    public float RayLength => _rayLength;
    public float platformOffset = 3f;

    /*private void Checkplatform()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Ray backray = new Ray(transform.position, -transform.forward);
        RaycastHit hit;

        float mouse = Input.GetAxis("Mouse X") * 2;
        float mouseY = Input.GetAxis("Mouse Y");

        /*if (Input.GetAxis("Mouse Y") * 2 > 0.3)
            Debug.Log("Удвоение" + Input.GetAxis("Mouse Y") * 2);#1#

        /*
        if (Input.GetAxis("Mouse Y") > 0.3)
            Debug.Log("Просто " + Input.GetAxis("Mouse Y"));#1#

        /*Debug.Log("Mouse Direction: " + mouse);
        Debug.Log("Mouse Direction: " + new Vector3(mouse, 0, 0).normalized);#1#
        Vector3 New = new Vector3(mouse, 0, mouseY).normalized;
        // Debug.Log(New.z);
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
                // _direction = Vector3.Reflect(_direction, hit.normal);


                Vector3 Reflect = Vector3.Reflect(_direction, hit.normal);

                // Debug.Log("Reflect " + Reflect);
                if (New.z > 0.5 || New.z < -0.3)
                {
                    // Debug.Log("Z " + New.z);
                    _direction = new Vector3(Reflect.x , Reflect.y, Reflect.z+ New.z).normalized;
                    Debug.Log("Пров " + _direction);
                    speed = Mathf.Clamp((speed * 2), _maxSpeed, _ultraSpeed);
                }
                else
                {
                    _direction = Reflect;
                }

                if (New.x > 0.3 || New.x < -0.3)
                {
                    // Debug.Log("X");
                    _direction = new Vector3(Reflect.x + New.x, Reflect.y, Reflect.z).normalized;
                }
                else
                {
                    _direction = Reflect;
                }

                // Debug.Log("UP");
            }
        }

        if (Physics.Raycast(backray, out hit, _rayLength))
        {
            if (hit.collider.gameObject.TryGetComponent(out PlatformController platformController) ||
                hit.collider.gameObject.TryGetComponent(out PlatformaMover testPlatformaMover))
            {
                Vector3 platformUp = hit.transform.forward;
                Vector3 newPosition = hit.point + platformUp * platformOffset;
                transform.position = newPosition;
                // _direction = Vector3.Reflect(_direction, hit.normal);


                Vector3 Reflect = Vector3.Reflect(_direction, hit.normal);

                // Debug.Log("Reflect " + Reflect);

                if (New.z > 0.5 || New.z < -0.3)
                {
                    Debug.Log("Z " + New.z);
                    _direction = new Vector3(Reflect.x , Reflect.y, Reflect.z+ New.z).normalized;
                    Debug.Log(_direction);
                    speed = Mathf.Clamp((speed * 2), _maxSpeed, _ultraSpeed);
                }
                else
                {
                    _direction = Reflect;
                }
                
                
                if (New.x > 0.3 || New.x < -0.3)
                {
                    _direction = new Vector3(Reflect.x + New.x, Reflect.y, Reflect.z).normalized;
                }
                else
                {
                    _direction = Reflect;
                }

                // Debug.Log("Down");
                /*Debug.Log(_direction.x + "  ...   "+ New.x);
                Debug.Log("NEW " + _direction);#1#
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * _rayLength, Color.red);
        Debug.DrawRay(backray.origin, backray.direction * _rayLength, Color.green);
    }*/

    public void SetDirection(Vector3 direction)
    {
        Debug.Log("SETDIRECTION" + direction);
        _direction = direction;
    }

    public void FastSpeed()
    {
        speed = Mathf.Clamp((speed * 2), _maxSpeed, _ultraSpeed);
    }

    private void CheckBehindWall()
    {
        if (transform.position.x > _xMaxPosition)
        {
            Vector3 normal = new Vector3(-1, 0, 0);
            var position = transform.position;
            position = new Vector3(_xMaxPosition, position.y, position.z);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
            Debug.Log("Ушел с права " + _direction);
        }

        if (transform.position.x < _xMinPosition)
        {
            Vector3 normal = new Vector3(1, 0, 0);
            var position = transform.position;
            position = new Vector3(_xMinPosition, position.y, position.z);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
            Debug.Log("Ушел с лева " + _direction);
        }
        
        if (transform.position.z> _zMaxPosition)
        {
            Vector3 normal = new Vector3(0, 0, -1);
            var position = transform.position;
            position = new Vector3(position.x, position.y, _zMaxPosition);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
            Debug.Log("Ушел с лева " + _direction);
        }


        /*Vector3 predictedPosition = transform.position + direction * speed * Time.deltaTime;
    
        if (transform.position.x > _xMaxPosition)
        {
            transform.position = new Vector3(_xMaxPosition, transform.position.y, transform.position.z);
    
            if (Physics.SphereCast(transform.position, radius, _direction, out RaycastHit hit,
                (predictedPosition - transform.position).magnitude, wallLayer))
            {
                _direction = Vector3.Reflect(_direction, hit.normal);
                Debug.Log("УшелВБольше");
            }
        }
    
        if (transform.position.x < _xMinPosition)
        {
            transform.position = new Vector3(_xMinPosition, transform.position.y, transform.position.z);
    
            if (Physics.SphereCast(transform.position, radius, _direction, out RaycastHit hit,
                (predictedPosition - transform.position).magnitude, wallLayer))
            {
                _direction = Vector3.Reflect(_direction, hit.normal);
                Debug.Log("УшелВМеньше");
            }
        }*/
    }

    private void CheckAngle()
    {
        if (_direction.z == 0)
        {
            Debug.Log("ZERO " + _direction.z);
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.5f, 0.5f))
                .normalized;
        }

        if (_direction.z < 0 && _direction.z > -0.3)
        {
            Debug.Log("DIREC " + _direction.z);
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.3f, -0.5f))
                .normalized;
        }

        if (_direction.z > 0 && _direction.z < 0.3)
        {
            Debug.Log("DIREC БОЛЬШЕ " + _direction.z);
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(0.3f, 0.5f))
                .normalized;
        }
    }
    
    public void SetValue(bool portalActivated)
    {
        _isPortal = portalActivated;
    }
}
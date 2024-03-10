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
    
    public float MinSpeed { get; private set; } = 30;
    private float _mediumSpeed = 45;
    private float _maxSpeed = 60f;

    public float speed;

    public LayerMask wallLayer;
    private Vector3 _direction;
    public float _radius;
    private bool _isSpeedUp;

    public float Speed => speed;
    public Vector3 Direction => _direction;

    [SerializeField] private float _rayLength = 10f;
    public float RayLength => _rayLength;
    public float platformOffset = 3f;
    

    void Start()
    {
        _radius = GetComponent<SphereCollider>().radius;
    }

    void Update()
    {
        if (speed > MinSpeed && !_isSpeedUp)
        {
            speed = Mathf.MoveTowards(speed, MinSpeed, 6f * Time.deltaTime);
        }

        if (speed < MinSpeed)
        {
            speed = MinSpeed;
        }

        if (transform.position.y != 5.1f)
        {
            Debug.Log("По Y не то");
            transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
        }
        // transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
        
        _ballTrigger.CheckPlatformCollision();
        Vector3 predictedPosition = transform.position + _direction * speed * Time.deltaTime;

        // if (Physics.SphereCast(transform.position, _radius, _direction, out RaycastHit hit,
        //     (predictedPosition - transform.position).magnitude, wallLayer))
        // {
        //
        //     _direction = Vector3.Reflect(_direction, hit.normal);
        //
        //     if (_direction.z == 0)
        //     {
        //         _direction = new Vector3(_direction.x, 5.1f, _direction.z + Random.Range(-0.5f, 0.5f))
        //             .normalized;
        //     }
        //
        //     if (_direction.z < 0 && _direction.z > -0.3)
        //     {
        //         _direction = new Vector3(_direction.x, 5.1f, _direction.z + Random.Range(-0.3f, -0.5f))
        //             .normalized;
        //     }
        //
        //     if (_direction.z > 0 && _direction.z < 0.3)
        //     {
        //         _direction = new Vector3(_direction.x, 5.1f, _direction.z + Random.Range(0.3f, 0.5f))
        //             .normalized;
        //     }
        // }
        
        if (_isPortal)
            _portalTeleporterBall.TeleportBall();

        else
            CheckBehindWall();

        transform.position += _direction * speed * Time.deltaTime;
        
        /*else
        {
            if (_isPortal)
                _portalTeleporterBall.TeleportBall();

            else
                CheckBehindWall();

            transform.position += _direction * speed * Time.deltaTime;
        }*/
    }

    public void SetStartDirection(Vector3 direction)
    {
        _direction = direction;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Brick brick))
        {
            Vector3 Reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
            // Debug.Log("Reflect " + Reflect);
            Vector3 NEWREFLECT = new Vector3(Reflect.x, 0, Reflect.z).normalized;
// Debug.Log("Newreflect " + NEWREFLECT);
            _direction = NEWREFLECT;
            
            
            // _direction = Vector3.Reflect(_direction, other.GetContact(0).normal);
            brick.Die();
        }

        if (other.collider.TryGetComponent(out Wall wall))
        {
            Vector3 Reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
            Vector3 NEWREFLECT = new Vector3(Reflect.x, 0, Reflect.z).normalized;
            _direction = NEWREFLECT;
        }
    }

    public void SetValue(float speed, bool flag)
    {
        _isSpeedUp = flag;
        this.speed = Mathf.Clamp(speed, MinSpeed, _maxSpeed);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction;
    }

    public void FastSpeed()
    {
        if (!_isSpeedUp)
            speed = Mathf.Clamp((speed * 1.5f), MinSpeed, _mediumSpeed);
    }

    private void CheckBehindWall()
    {
        if (transform.position.x > _xMaxPosition)
        {
            Vector3 normal = new Vector3(-1, 0, 0);
            var position = transform.position;
            // position = new Vector3(_xMaxPosition, position.y, position.z);
            position = new Vector3(_xMaxPosition, 5.1f, position.z);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
        }

        if (transform.position.x < _xMinPosition)
        {
            Vector3 normal = new Vector3(1, 0, 0);
            var position = transform.position;
            // position = new Vector3(_xMinPosition, position.y, position.z);
            position = new Vector3(_xMinPosition, 5.1f, position.z);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
        }

        if (transform.position.z > _zMaxPosition)
        {
            Vector3 normal = new Vector3(0, 0, -1);
            var position = transform.position;
            // position = new Vector3(position.x, position.y, _zMaxPosition);
            position = new Vector3(position.x, 5.1f, _zMaxPosition);
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
        }
    }

    private void CheckAngle()
    {
        if (_direction.z == 0)
        {
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.5f, 0.5f))
                .normalized;
        }

        if (_direction.z < 0 && _direction.z > -0.3)
        {
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.3f, -0.5f))
                .normalized;
        }

        if (_direction.z > 0 && _direction.z < 0.3)
        {
            _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(0.3f, 0.5f))
                .normalized;
        }
    }

    public void SetValue(bool portalActivated)
    {
        _isPortal = portalActivated;
    }
}
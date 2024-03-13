using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2BrickMover : MonoBehaviour
{
    [SerializeField] private float _moveDistanceForward;
    [SerializeField] private float _moveDistanceBack;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _duration;
    [SerializeField] private Brick[] _bricks;

    private Vector3 _initialPosition;
    private Vector3 _targetPosition;
    private Vector3 _targetPosition1;
    private bool _isPaused = false;
    private bool _isTargetPosition = false;
    private WaitForSeconds _waitForSeconds;
    private Coroutine _coroutine;

    public Transform target1;
    public Transform target2;
    public float moveDuration = 1.0f; // Длительность движения между точками (в секундах)
    private Vector3 _direction;
    private bool isMovingToTarget1 = true;

    private void Start()
    {
        _initialPosition = transform.position;
        _waitForSeconds = new WaitForSeconds(_duration);
        _targetPosition =
            new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z - _moveDistanceForward);
        _targetPosition1 = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z + _moveDistanceBack);

        foreach (var brick in _bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = true;
        }

        _coroutine = StartCoroutine(MoveBetweenTargetsCoroutine());
    }

    private IEnumerator MoveBetweenTargetsCoroutine()
    {
        yield return _waitForSeconds;

        while (true)
        {
            if (isMovingToTarget1)
            {
                yield return MoveToTarget(_targetPosition, moveDuration);
            }
            else
            {
                yield return MoveToTarget(_targetPosition1, moveDuration);
            }

            isMovingToTarget1 = !isMovingToTarget1;
        }
    }

    private IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;

        while (Time.time < startTime + duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            
            _direction = startPosition - targetPosition;
            // Debug.Log( "Направление " + _direction);

            foreach (Brick brick in _bricks)
            {
                brick.transform.position = new Vector3(brick.transform.position.x, brick.transform.position.y,
                    transform.position.z);
            }

            yield return null;
        }

        transform.position = targetPosition;

        foreach (Brick brick in _bricks)
        {
            brick.transform.position = new Vector3(brick.transform.position.x, brick.transform.position.y,
                transform.position.z);
        }
    }


    /*void Start()
    {
        _initialPosition = transform.position;
        _waitForSeconds = new WaitForSeconds(_duration);
        _targetPosition = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z - _moveDistanceForward);
        _targetPosition1 = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z + _moveDistanceBack);

        foreach (var brick in _bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void Update()
    {
        BricksMove();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BallMover ballMover) || other.TryGetComponent(out Bullet bullet))
        {
            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
                brick.GetComponent<Rigidbody>().AddForce(-_direction.normalized * Random.Range(6f, 15f), ForceMode.Impulse);
                // StopCoroutine(_coroutine);
            }

            // this.enabled = false;
            gameObject.SetActive(false);
        }
    }

    private void BricksMove()
    {
        if (!_isTargetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            foreach (Brick brick in _bricks)
            {
                brick.transform.position = new Vector3(brick.transform.position.x, brick.transform.position.y,
                    transform.position.z);
            }

            if (transform.position == _targetPosition)
            {
                _isTargetPosition = true;
                // ActivatedPause();
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition1, _moveSpeed * Time.deltaTime);

            foreach (Brick brick in _bricks)
            {
                brick.transform.position = new Vector3(transform.position.x, brick.transform.position.y,
                    transform.position.z);
                ;
            }

            if (transform.position == _targetPosition1)
            {
                _isTargetPosition = false;
                // ActivatedPause();
            }
        }
    }
}
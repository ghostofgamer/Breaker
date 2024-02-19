using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMover : MonoBehaviour
{
    [SerializeField] private float _jumpHeight = 2.0f;
    [SerializeField] private float _jumpDuration = 1.0f;
    [SerializeField] private float _speed = 6f;
    [SerializeField] private float _reducerJumpHeight = 1f;

    private int _maxJumps = 5;
    private int _currentJumps = 0;
    private float _startY;
    private bool _isJumping = false;
    private float _startTime;
    private float _maxJumpProgress = 1f;
    private Vector3 _direction;
    
    public float minAngle = -15f;
    public float maxAngle = 15f;


    void Start()
    {
        _startY = transform.position.y;
        
        float angle = UnityEngine.Random.Range(minAngle, maxAngle);
        _direction = Quaternion.AngleAxis(angle, Vector3.up) * -Vector3.forward;
    }

    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
        // transform.Translate(-Vector3.forward * _speed * Time.deltaTime);
        Jump();
    }

    private void Jump()
    {
        if (!_isJumping && _currentJumps < _maxJumps)
        {
            float newAngle = UnityEngine.Random.Range(minAngle, maxAngle);
            _direction = Quaternion.AngleAxis(newAngle, Vector3.up) * -Vector3.forward;
            _isJumping = true;
            _startTime = Time.time;
            _startY = transform.position.y;
            _currentJumps++;
        }

        if (_isJumping)
        {
            float timeSinceStart = Time.time - _startTime;
            float jumpProgress = timeSinceStart / _jumpDuration;

            if (jumpProgress < _maxJumpProgress)
            {
                float newY = _startY + Mathf.Sin(jumpProgress * Mathf.PI) * _jumpHeight;
                transform.position = new Vector3(transform.position.x, newY, transform.position.z);
            }
            else
            {
                _jumpHeight -= _reducerJumpHeight;
                _isJumping = false;
            }
        }
    }
}
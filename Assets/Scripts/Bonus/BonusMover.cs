using UnityEngine;

namespace Bonus
{
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
        private float _minAngle = -15f;
        private float _maxAngle = 15f;
        private float _minX = -11f;
        private float _maxX = 11f;
        private float _currentX;

        void Start()
        {
            _startY = transform.position.y;
            float angle = Random.Range(_minAngle, _maxAngle);
            _direction = Quaternion.AngleAxis(angle, Vector3.up) * -Vector3.forward;
        }

        void Update()
        {
            transform.position += _direction * (_speed * Time.deltaTime);
            _currentX = Mathf.Clamp(transform.position.x, _minX, _maxX);
            transform.position = new Vector3(_currentX, transform.position.y, transform.position.z);
            Jump();
        }

        private void Jump()
        {
            if (!_isJumping && _currentJumps < _maxJumps)
            {
                float newAngle = Random.Range(_minAngle, _maxAngle);
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
}
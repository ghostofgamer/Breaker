using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace ModificationFiles
{
    public class BuffMover : MonoBehaviour
    {
        [SerializeField] private float _jumpHeight = 2.0f;
        [SerializeField] private float _jumpDuration = 1.0f;
        [SerializeField] private float _speed = 6f;

        private int _maxJumps = 3;
        private int _currentJumps = 0;
        private float _startY;
        private bool _isJumping = false;
        private float _startTime;
        private float _maxJumpProgress = 1f;
        private float _reducerJumpHeight = 1f;

        private float _minX = -11f;
        private float _maxX = 11f;
        private float _currentX;

        void Start()
        {
            _startY = transform.position.y;
        }

        void Update()
        {
            transform.Translate(-Vector3.forward * _speed * Time.deltaTime);
            _currentX = Mathf.Clamp(transform.position.x, _minX, _maxX);
            transform.position = new Vector3(_currentX, transform.position.y, transform.position.z);
            Jump();
        }

        private void Jump()
        {
            if (!_isJumping && _currentJumps < _maxJumps)
            {
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
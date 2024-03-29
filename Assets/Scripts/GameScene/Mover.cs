using UnityEngine;

namespace GameScene
{
    public abstract class Mover : MonoBehaviour
    {
        [SerializeField] private float _jumpHeight;
        [SerializeField] private float _jumpDuration;
        [SerializeField] private float _speed;
        [SerializeField]private int _maxJumps;
        [SerializeField]private float _reducerJumpHeight;

        private int _currentJumps = 0;
        private float _startY;
        private bool _isJumping = false;
        private float _startTime;
        private float _maxJumpProgress = 1f;
        private float _currentX;
        private float _minX = -11f;
        private float _maxX = 11f;

        public float Speed => _speed;
    
        protected virtual void Start()
        {
            _startY = transform.position.y;
        }
    
        protected virtual void Update()
        {
            _currentX = Mathf.Clamp(transform.position.x, _minX, _maxX);
            transform.position = new Vector3(_currentX, transform.position.y, transform.position.z);
            Jump();
        }

        protected virtual void JumpActivation()
        {
            _isJumping = true;
            _startTime = Time.time;
            _startY = transform.position.y;
            _currentJumps++;
        }

        private void Jump()
        {
            if (!_isJumping && _currentJumps < _maxJumps)
            {
                JumpActivation();
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

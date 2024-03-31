using Statistics;
using UnityEngine;

namespace GameScene.BallContent
{
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private PortalTeleporterBall _portalTeleporterBall;
        [SerializeField] private bool _isPortal = false;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private Ball _ball;
        [SerializeField] private BallDirection _ballDirection;
        [SerializeField] private BrickCounter _brickCounter;

        private float _mediumSpeed = 45;
        private float _maxSpeed = 60f;
        private float _maxY = 5.1f;
        private float _speed = 30f;
        private float _speedUpValue = 1.5f;
        private bool _isSpeedUp;
        private float _stoppingSpeed = 6f;
        private float _factor = 3f;
        private Rigidbody _rigidbody;

        public float MinSpeed { get; private set; } = 30;

        public bool IsMoving { get; private set; }

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnStopMove;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnStopMove;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            OnStopMove();
        }

        private void Update()
        {
            if (!IsMoving && !_ball.IsWin)
            {
                var position = _ball.BaseMovement.transform.position;
                transform.position = new Vector3(position.x, position.y, position.z + _factor);
            }

            if (IsMoving)
            {
                if (_speed > MinSpeed && !_isSpeedUp)
                    _speed = Mathf.MoveTowards(_speed, MinSpeed, _stoppingSpeed * Time.deltaTime);

                if (_speed < MinSpeed)
                    _speed = MinSpeed;

                if (transform.position.y != _maxY)
                    transform.position = new Vector3(transform.position.x, _maxY, transform.position.z);

                _ballTrigger.CheckPlatformCollision();

                if (_isPortal)
                    _portalTeleporterBall.PortalTravel();
                else
                    _ballDirection.CheckBehindWall();

                transform.position += _ballDirection.Direction * (_speed * Time.deltaTime);
                transform.Rotate(_ballDirection.Direction);
            }
        }

        public void SetMove(float directionX)
        {
            IsMoving = true;
            _rigidbody.isKinematic = false;
            _ballDirection.SetStartDirection(directionX);
        }

        public void OnStopMove()
        {
            IsMoving = false;
            _rigidbody.isKinematic = true;
        }

        public void EnableSpeedUpEffect()
        {
            _isSpeedUp = true;
            _speed = _maxSpeed;
        }

        public void DisableSpeedUpEffect()
        {
            _isSpeedUp = false;
            _speed = MinSpeed;
        }

        public void PortalActivated()
        {
            _isPortal = true;
        }

        public void PortalDeactivation()
        {
            _isPortal = false;
        }

        public void IncreaseSpeed()
        {
            if (!_isSpeedUp)
                _speed = Mathf.Clamp(_speed * _speedUpValue, MinSpeed, _mediumSpeed);
        }
    }
}
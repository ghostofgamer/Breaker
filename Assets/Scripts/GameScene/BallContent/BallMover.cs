using Bricks;
using PlayerFiles.ModificationContent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GameScene.BallContent
{
    public class BallMover : MonoBehaviour
    {
        [SerializeField] private PortalTeleporterBall _portalTeleporterBall;
        [SerializeField] private float _xMinPosition;
        [SerializeField] private float _xMaxPosition;
        [SerializeField] private float _zMaxPosition;
        [SerializeField] private bool _isPortal = false;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private ElectricBall _electricBall;
        [SerializeField] private Ball _ball;

        private float _mediumSpeed = 45;
        private float _maxSpeed = 60f;
        private Vector3 _direction;
        private float _maxY = 5.1f;
        private float _speed = 30f;
        private float _speedUpValue = 1.5f;
        private bool _isSpeedUp;
        private int _directionMove = 1;
        private float _stoppingSpeed = 6f;
        private float _maxAngleValue = 0.5f;
        private float _minAngleValue = 0.3f;
        private float _minValueZ = 0.35f;
        private float _factor = 3f;
        private float _valueEnableFastSpeed = 0.5f;
        private float _valuePush = 0.3f;

        public float MinSpeed { get; private set; } = 30;

        public Vector3 Direction => _direction;

        private void Update()
        {
            if (!_ball.IsMoving && !_ball.IsWin)
            {
                var position = _ball.BaseMovement.transform.position;
                transform.position = new Vector3(position.x, position.y, position.z + _factor);
            }

            if (_ball.IsMoving)
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
                    CheckBehindWall();

                transform.position += _direction * _speed * Time.deltaTime;
                transform.Rotate(_direction);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Brick brick))
            {
                if (_electricBall.gameObject.activeSelf && !brick.IsEternal)
                {
                    _electricBall.DestroyBrick(brick);
                    return;
                }

                Vector3 reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
                Vector3 newReflect = new Vector3(reflect.x, 0, reflect.z).normalized;
                _direction = newReflect;
                brick.Die();
            }

            if (other.collider.TryGetComponent(out Wall wall) ||
                other.collider.TryGetComponent(out WallTrigger wallTrigger))
            {
                Vector3 reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
                Vector3 newReflect = new Vector3(reflect.x, 0, reflect.z).normalized;
                _direction = newReflect;
                CheckAngle();
            }
        }

        public void SetStartDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void SetValue(float speed, bool flag)
        {
            _isSpeedUp = flag;
            this._speed = Mathf.Clamp(speed, MinSpeed, _maxSpeed);
        }

        public void SetValue(bool portalActivated)
        {
            _isPortal = portalActivated;
        }

        public void ChangeDirection(Vector3 vector, Vector3 hit)
        {
            Vector3 reflect = Vector3.Reflect(Direction, hit);
            Vector3 newReflect = new Vector3(reflect.x, reflect.y, 1).normalized;

            if (vector.z > _valueEnableFastSpeed)
            {
                SetDirection(new Vector3(reflect.x, reflect.y, reflect.z + vector.z).normalized);
                IncreaseSpeed();
            }
            else
            {
                SetDirection(newReflect);
            }

            if (vector.x > _valuePush || vector.x < -_valuePush)
            {
                SetDirection(new Vector3(reflect.x + vector.x, reflect.y, newReflect.z).normalized);
            }
            else
            {
                SetDirection(newReflect);
            }
        }

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        private void IncreaseSpeed()
        {
            if (!_isSpeedUp)
                _speed = Mathf.Clamp(_speed * _speedUpValue, MinSpeed, _mediumSpeed);
        }

        private void CheckBehindWall()
        {
            if (transform.position.x > _xMaxPosition)
            {
                SetDirection(
                    new Vector3(-_directionMove, 0, 0),
                    new Vector3(_xMaxPosition, _maxY, transform.position.z));
            }

            if (transform.position.x < _xMinPosition)
            {
                SetDirection(
                    new Vector3(_directionMove, 0, 0),
                    new Vector3(_xMinPosition, _maxY, transform.position.z));
            }

            if (transform.position.z > _zMaxPosition)
            {
                SetDirection(
                    new Vector3(0, 0, -_directionMove),
                    new Vector3(transform.position.x, _maxY, _zMaxPosition));
            }
        }

        private void SetDirection(Vector3 vectorNormal, Vector3 newVector)
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            Vector3 normal = vectorNormal;
            Vector3 position = newVector;
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
        }

        private void CheckAngle()
        {
            _audioSource.PlayOneShot(_audioSource.clip);

            if (_direction.z == 0)
                ChangeAngle(_direction.z + Random.Range(-_maxAngleValue, _maxAngleValue));

            if (_direction.z < 0 && _direction.z > -_minValueZ)
                ChangeAngle(_direction.z + Random.Range(-_minAngleValue, _maxAngleValue));

            if (_direction.z > 0 && _direction.z < _minValueZ)
                ChangeAngle(_direction.z + Random.Range(_minAngleValue, _maxAngleValue));
        }

        private void ChangeAngle(float zValue)
        {
            _direction = new Vector3(_direction.x, _direction.y, zValue).normalized;
        }
    }
}
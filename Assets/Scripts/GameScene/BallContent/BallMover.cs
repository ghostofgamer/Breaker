using Bricks;
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
        [SerializeField] private float _zMinPosition;
        [SerializeField] private bool _isPortal = false;
        [SerializeField] private BallTrigger _ballTrigger;
        [SerializeField] private float _rayLength = 10f;

        private float _mediumSpeed = 45;
        private float _maxSpeed = 60f;
        private Vector3 _direction;
        private float _maxY = 5.1f;

        private float _speed = 30f;

        // public LayerMask _wallLayer;
        public float _radius;
        private bool _isSpeedUp;

        public float MinSpeed { get; private set; } = 30;

        public float Speed => _speed;
        public Vector3 Direction => _direction;


        // public float RayLength => _rayLength;
        // public float _platformOffset = 3f;


        void Start()
        {
            _radius = GetComponent<SphereCollider>().radius;
        }

        void Update()
        {
            if (_speed > MinSpeed && !_isSpeedUp)
            {
                _speed = Mathf.MoveTowards(_speed, MinSpeed, 6f * Time.deltaTime);
            }

            if (_speed < MinSpeed)
            {
                _speed = MinSpeed;
            }

            if (transform.position.y != _maxY)
            {
                transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
            }

            _ballTrigger.CheckPlatformCollision();
            Vector3 predictedPosition = transform.position + _direction * _speed * Time.deltaTime;

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

            transform.position += _direction * _speed * Time.deltaTime;

            // transform.Rotate(0,1,1);
            transform.Rotate(_direction);


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
                Vector3 reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
                Vector3 newReflect = new Vector3(reflect.x, 0, reflect.z).normalized;
                _direction = newReflect;


                // _direction = Vector3.Reflect(_direction, other.GetContact(0).normal);
                brick.Die();
            }

            if (other.collider.TryGetComponent(out Wall wall))
            {
                Vector3 reflect = Vector3.Reflect(_direction, other.GetContact(0).normal);
                Vector3 newReflect = new Vector3(reflect.x, 0, reflect.z).normalized;
                _direction = newReflect;
            }
        }

        public void SetValue(float speed, bool flag)
        {
            _isSpeedUp = flag;
            this._speed = Mathf.Clamp(speed, MinSpeed, _maxSpeed);
        }

        public void SetDirection(Vector3 direction)
        {
            _direction = direction;
        }

        public void FastSpeed()
        {
            if (!_isSpeedUp)
                _speed = Mathf.Clamp((_speed * 1.5f), MinSpeed, _mediumSpeed);
        }

        private void CheckBehindWall()
        {
            if (transform.position.x > _xMaxPosition)
            {
                SetDirection(new Vector3(-1, 0, 0),new Vector3(_xMaxPosition, 5.1f, transform.position.z));
            }

            if (transform.position.x < _xMinPosition)
            {
                SetDirection(new Vector3(1, 0, 0),new Vector3(_xMinPosition, 5.1f, transform.position.z));
            }

            if (transform.position.z > _zMaxPosition)
            {
                Debug.Log("МАКСИМУМ");
                SetDirection(new Vector3(0, 0, -1),new Vector3(transform.position.x, 5.1f, _zMaxPosition));
            }
        }

        private void SetDirection(Vector3 vectorNormal,Vector3 newVector )
        {
            Vector3 normal = vectorNormal;
            var position = transform.position;
            position = newVector;
            transform.position = position;
            _direction = Vector3.Reflect(_direction, normal);
            CheckAngle();
            Debug.Log(_direction);
        }
        
        private void CheckAngle()
        {
            if (_direction.z == 0)
            {
                Debug.Log("В ноль");
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.5f, 0.5f))
                    .normalized;
                Debug.Log("В ноль " + _direction );
            }

            if (_direction.z < 0 && _direction.z > -0.35)
            {
                Debug.Log("В минус");
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(-0.3f, -0.5f))
                    .normalized;
                Debug.Log("В минус" + _direction);
            }

            if (_direction.z > 0 && _direction.z < 0.35)
            {
                Debug.Log("В плюс");
                _direction = new Vector3(_direction.x, _direction.y, _direction.z + Random.Range(0.3f, 0.5f))
                    .normalized;
                Debug.Log("В плюс " + _direction);
            }
        }

        public void SetValue(bool portalActivated)
        {
            _isPortal = portalActivated;
        }
    }
}
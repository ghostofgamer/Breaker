using UnityEngine;

namespace GameScene.BallContent
{
    public class BallDirection : MonoBehaviour
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";
        
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private BallMover _ballMover;

        private float _xMinPosition = -13f;
        private float _xMaxPosition = 13f;
        private float _zMaxPosition = 37;
        private Vector3 _direction;
        private float _valueEnableFastSpeed = 0.5f;
        private float _valuePush = 0.3f;
        private float _maxAngleValue = 0.5f;
        private float _minAngleValue = 0.3f;
        private float _minValueZ = 0.35f;
        private int _directionMove = 1;
        private float _maxY = 5.1f;
        private float _directionForward = 1;
        private int _factor = 2;
        
        public Vector3 Direction => _direction;

        public void SetStartDirection(float directionX)
        {
            _direction = new Vector3(directionX, 0, _directionForward).normalized;
        }

        public void DirectReflection(Vector3 platformNormal)
        {
            float mouse = Input.GetAxis(MouseX) * _factor;
            float mouseY = Input.GetAxis(MouseY);
            Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
            ChangeDirection(newVector, platformNormal);
        }
        
        public void ReflectBall(Vector3 normal)
        {
            Vector3 reflect = Vector3.Reflect(_direction, normal);
            Vector3 newReflect = new Vector3(reflect.x, 0, reflect.z).normalized;
            _direction = newReflect;
            CheckAngle();
        }

        public void ChangeDirection(Vector3 vector, Vector3 hit)
        {
            Vector3 reflect = Vector3.Reflect(Direction, hit);
            Vector3 newReflect = new Vector3(reflect.x, reflect.y, 1).normalized;

            if (vector.z > _valueEnableFastSpeed)
            {
                SetDirection(new Vector3(reflect.x, reflect.y, reflect.z + vector.z).normalized);
                _ballMover.IncreaseSpeed();
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

        public void CheckBehindWall()
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

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
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
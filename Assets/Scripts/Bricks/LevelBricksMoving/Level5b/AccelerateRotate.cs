using UnityEngine;

namespace Bricks.LevelBricksMoving.Level5b
{
    public class AccelerateRotate : MonoBehaviour
    {
        private float _maxSpeed = 100.0f;
        private float _accelerationTime = 3f;
        private float _currentSpeed;
        private float _acceleration;

        public float MaxSpeed => _maxSpeed;

        private void Start()
        {
            _acceleration = _maxSpeed / _accelerationTime;
        }

        private void Update()
        {
            if (_currentSpeed < _maxSpeed)
                _currentSpeed += _acceleration * Time.deltaTime;

            transform.Rotate(Vector3.up, _currentSpeed * Time.deltaTime);
        }

        public void StartRotation()
        {
            _currentSpeed = 0;
            enabled = true;
        }

        public void StopRotation()
        {
            enabled = false;
        }
    }
}
using UnityEngine;

namespace Levels
{
    public class LevelCubeJumping : MonoBehaviour
    {
        private float _speed = 3;
        private float _maxHeight = 1f;
        private Vector3 _startPosition;
        private bool _movingUp = true;
        private float _value = 1;

        void Start()
        {
            _startPosition = transform.position;
        }

        void Update()
        {
            float newY = transform.position.y + (_movingUp ? _value : -_value) * _speed * Time.deltaTime;

            if (_movingUp && newY >= _startPosition.y + _maxHeight)
                _movingUp = false;

            else if (!_movingUp && newY <= _startPosition.y)
                _movingUp = true;

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}
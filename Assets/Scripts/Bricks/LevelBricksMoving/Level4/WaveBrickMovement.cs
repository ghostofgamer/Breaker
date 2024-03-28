using UnityEngine;

namespace Bricks.LevelBricksMoving.Level4
{
    public class WaveBrickMovement : MonoBehaviour
    {
        private float _speed = 3f;
        private float _amplitude = 2.3f;
        private float _frequency = 3f;
        private Vector3 _initialPosition;
        private float _zPosition;

        private void Start()
        {
            _initialPosition = transform.position;
        }

        private void Update()
        {
            _zPosition = _initialPosition.z +
                         Mathf.Sin(Time.time * _speed + transform.position.x * _frequency) * _amplitude;
            transform.position = new Vector3(transform.position.x, transform.position.y, _zPosition);
        }
    }
}
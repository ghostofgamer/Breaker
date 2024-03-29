using UnityEngine;

namespace Bricks.LevelBricksMoving.Level5b
{
    public class DecelerateStop : MonoBehaviour
    {
        private float _decelerationTime = 3.0f;
        private float _currentSpeed;
        private float _deceleration;

        public void StartDeceleration(float startSpeed)
        {
            enabled = true;
            _currentSpeed = startSpeed;
            _deceleration = _currentSpeed / _decelerationTime;
        }

        private void Update()
        {
            if (_currentSpeed > 0.0f)
                _currentSpeed -= _deceleration * Time.deltaTime;
            else
                enabled = false;

            transform.Rotate(Vector3.up, _currentSpeed * Time.deltaTime);
        }
    }
}
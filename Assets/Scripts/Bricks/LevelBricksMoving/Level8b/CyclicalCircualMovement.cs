using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level8b
{
    public class CyclicalCircualMovement : MotionController
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementDistance;
        [SerializeField] private PlatformaMover _platformaMover;

        private float _startZPosition;
        private Vector3 _targetPosition;
        private float _directionRotate;
        private bool _movingToStartPosition;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);

        private void Start()
        {
            _startZPosition = transform.position.z;
            _movingToStartPosition = false;
            StartCoroutine(MoveCyclically());
        }

        private IEnumerator MoveCyclically()
        {
            while (IsWork)
            {
                var position = transform.position;
                Vector3 targetPosition = _movingToStartPosition
                    ? new Vector3(position.x, position.y, _startZPosition)
                    : new Vector3(position.x, position.y, _startZPosition + _movementDistance);

                position = Vector3.MoveTowards(position, targetPosition, _movementSpeed * Time.deltaTime);
                transform.position = position;

                if (_platformaMover != null)
                    transform.Rotate(0, -_platformaMover.DirectionX * _rotateSpeed, 0);

                if (transform.position == targetPosition)
                {
                    yield return _waitForSeconds;
                    _movingToStartPosition = !_movingToStartPosition;
                }

                yield return null;
            }
        }
    }
}
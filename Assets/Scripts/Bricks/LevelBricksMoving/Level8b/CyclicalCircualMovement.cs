using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level8b
{
    public class CyclicalCircualMovement : WorkChanger
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementDistance;
        [SerializeField] private PlatformaMover _platformaMover;

        private float _startZPosition;
        private Vector3 _position;
        private Vector3 _targetPosition;
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
                _position = transform.position;
                _targetPosition = _movingToStartPosition
                    ? new Vector3(_position.x, _position.y, _startZPosition)
                    : new Vector3(_position.x, _position.y, _startZPosition + _movementDistance);

                _position = Vector3.MoveTowards(_position, _targetPosition, _movementSpeed * Time.deltaTime);
                transform.position = _position;

                if (_platformaMover != null)
                    transform.Rotate(0, -_platformaMover.DirectionX * _rotateSpeed, 0);

                if (transform.position == _targetPosition)
                {
                    yield return _waitForSeconds;
                    _movingToStartPosition = !_movingToStartPosition;
                }

                yield return null;
            }
        }
    }
}
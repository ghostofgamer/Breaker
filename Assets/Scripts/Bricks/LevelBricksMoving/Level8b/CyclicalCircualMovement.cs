using System.Collections;
using PlayerFiles.PlatformaContent;
using Statistics;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level8b
{
    public class CyclicalCircualMovement : MonoBehaviour
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotateSpeed;
        [SerializeField] private float _movementDistance;
        [SerializeField] private PlatformaMover _platformaMover;
        [SerializeField] private BrickCounter _brickCounter;

        private float _startZPosition;
        private bool _isWork = true;
        private Vector3 _targetPosition;
        private float _directionRotate;
        private bool _movingToStartPosition;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += Stop;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= Stop;
        }

        private void Start()
        {
            _startZPosition = transform.position.z;
            _movingToStartPosition = false;
            StartCoroutine(MoveCyclically());
        }

        private IEnumerator MoveCyclically()
        {
            while (_isWork)
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

        /*private void SetTargetPosition(float zPosition)
    {
        _targetPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
        Debug.Log(_targetPosition);
    }*/

        private void Stop()
        {
            _isWork = false;
        }
    }
}
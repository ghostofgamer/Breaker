using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level2
{
    public class ImpulseMovement : BrickTrigger
    {
        [SerializeField] private float _moveDistanceForward;
        [SerializeField] private float _moveDistanceBack;
        [SerializeField] private float _duration;
        [SerializeField] private Brick[] _brickObjects;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;
        private Vector3 _targetPosition1;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;
        private float _moveDuration = 1.0f;
        private Vector3 _direction;
        private bool _isMovingToTarget = true;
        private float _minValue = 6;
        private float _maxValue = 15;
        private bool _isWork = true;

        protected override void Start()
        {
            base.Start();
            _initialPosition = transform.position;
            _waitForSeconds = new WaitForSeconds(_duration);
            _targetPosition = new Vector3(
                _initialPosition.x,
                _initialPosition.y,
                _initialPosition.z - _moveDistanceForward);
            _targetPosition1 = new Vector3(
                _initialPosition.x,
                _initialPosition.y,
                _initialPosition.z + _moveDistanceBack);

            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(MoveBetweenTargetsCoroutine());
        }

        protected override void OnShutdown()
        {
            GiveImpulse(_direction, _minValue, _maxValue);
            _isWork = false;
            StopCoroutine(_coroutine);
        }

        private IEnumerator MoveBetweenTargetsCoroutine()
        {
            yield return _waitForSeconds;

            while (_isWork)
            {
                if (_isMovingToTarget)
                    yield return MoveToTarget(_targetPosition, _moveDuration);
                else
                    yield return MoveToTarget(_targetPosition1, _moveDuration);

                _isMovingToTarget = !_isMovingToTarget;
            }
        }

        private IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
        {
            float startTime = Time.time;
            Vector3 startPosition = transform.position;

            while (Time.time < startTime + duration)
            {
                float progress = (Time.time - startTime) / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, progress);
                _direction = startPosition - targetPosition;
                SetPosition();
                yield return null;
            }

            transform.position = targetPosition;
            SetPosition();
        }

        private void SetPosition()
        {
            foreach (Brick brick in _brickObjects)
            {
                brick.transform.position = new Vector3(
                    brick.transform.position.x,
                    brick.transform.position.y,
                    transform.position.z);
            }
        }
    }
}
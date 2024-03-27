using System;
using System.Collections;
using BulletFiles;
using GameScene.BallContent;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bricks.LevelBricksMoving
{
    public class Level2BrickMover : MonoBehaviour
    {
        [SerializeField] private float _moveDistanceForward;
        [SerializeField] private float _moveDistanceBack;
        [SerializeField] private float _duration;
        [SerializeField] private Brick[] _bricks;

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
    
        private void Start()
        {
            _initialPosition = transform.position;
            _waitForSeconds = new WaitForSeconds(_duration);
            _targetPosition =
                new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z - _moveDistanceForward);
            _targetPosition1 = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z + _moveDistanceBack);

            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = true;
            }

            if(_coroutine!=null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(MoveBetweenTargetsCoroutine());
        }

        private void Update()
        {
            if (_bricks[0].gameObject.activeSelf)
                return;
            
            Over();
        }

        private IEnumerator MoveBetweenTargetsCoroutine()
        {
            yield return _waitForSeconds;

            while (true)
            {
                if (_isMovingToTarget)
                {
                    yield return MoveToTarget(_targetPosition, _moveDuration);
                }
                else
                {
                    yield return MoveToTarget(_targetPosition1, _moveDuration);
                }

                _isMovingToTarget = !_isMovingToTarget;
            }
        }

        private IEnumerator MoveToTarget(Vector3 targetPosition, float duration)
        {
            float startTime = Time.time;
            Vector3 startPosition = transform.position;

            while (Time.time < startTime + duration)
            {
                float t = (Time.time - startTime) / duration;
                transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                _direction = startPosition - targetPosition;

                foreach (Brick brick in _bricks)
                {
                    brick.transform.position = new Vector3(brick.transform.position.x, brick.transform.position.y,
                        transform.position.z);
                }

                yield return null;
            }

            transform.position = targetPosition;

            foreach (Brick brick in _bricks)
            {
                brick.transform.position = new Vector3(brick.transform.position.x, brick.transform.position.y,
                    transform.position.z);
            }
        }

        /*private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BallMover ballMover) || other.TryGetComponent(out Bullet bullet))
            {
                foreach (var brick in _bricks)
                {
                    brick.GetComponent<Rigidbody>().isKinematic = false;
                    brick.GetComponent<Rigidbody>().AddForce(-_direction.normalized * Random.Range(_minValue, _maxValue), ForceMode.Impulse);
                }

                gameObject.SetActive(false);
            }
        }*/

        private void Over()
        {
            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
                brick.GetComponent<Rigidbody>().AddForce(-_direction.normalized * Random.Range(_minValue, _maxValue), ForceMode.Impulse);
            }

            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

namespace Bricks.LevelBricksMoving.Level3
{
    public class Gyration : MotionController
    {
        [SerializeField] private Transform _pointA;
        [SerializeField] private Transform _pointB;
        [SerializeField] private Transform _center;
        [SerializeField] private float _rotationStart;
        [SerializeField] private float _endRotation;

        private Coroutine _coroutine;
        private float _minValue = 0.1f;
        private float _maxValue = 0.5f;
        private float _elapsedTime;
        private float _duration = 5;
        private bool _isMovingToTarget = true;
        private bool _name;

        private void Start()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(MoveCubes());
        }

        private IEnumerator MoveCubes()
        {
            while (IsWork)
            {
                if (_isMovingToTarget)
                    yield return Slerping(_pointA.position, _pointB.position, _rotationStart, _endRotation);
                else
                    yield return Slerping(_pointB.position, _pointA.position, _endRotation, _rotationStart);

                _isMovingToTarget = !_isMovingToTarget;
            }
        }

        private IEnumerator Slerping(Vector3 pointA, Vector3 pointB, float rotationA, float rotationB)
        {
            _elapsedTime = 0;
            float randomPause = Random.Range(_minValue, _maxValue);
            yield return new WaitForSeconds(randomPause);

            while (_elapsedTime < _duration)
            {
                CubeLerping(pointA, pointB, rotationA, rotationB);
                yield return null;
            }
        }

        private void CubeLerping(Vector3 pointA, Vector3 pointB, float rotationA, float rotationB)
        {
            _elapsedTime += Time.deltaTime;
            float progress = _elapsedTime / _duration;
            transform.position = Vector3.Slerp(
                pointA - _center.position,
                pointB - _center.position,
                progress) + _center.position;
            transform.rotation = Quaternion.Lerp(
                Quaternion.Euler(0, rotationA, 0),
                Quaternion.Euler(0, rotationB, 0), progress);
        }
    }
}
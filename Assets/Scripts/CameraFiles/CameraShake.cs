using System.Collections;
using Bricks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CameraFiles
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private float _duration = 0.5f;
        [SerializeField] private float _magnitude = 0.5f;
        [SerializeField] private BrickExplosion[] _brickExplosions;

        private Vector3 _originalPosition;
        private float _elapsedTime;
        private float _minValue = -1f;
        private float _maxValue = 1f;

        private void OnEnable()
        {
            foreach (var brick in _brickExplosions)
            {
                brick.Dead += OnShake;
            }
        }

        private void OnDisable()
        {
            foreach (var brick in _brickExplosions)
            {
                brick.Dead -= OnShake;
            }
        }

        private void OnShake()
        {
            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            _originalPosition = transform.localPosition;
            _elapsedTime = 0.0f;

            while (_elapsedTime < _duration)
            {
                float x = GetValue();
                float y = GetValue();

                transform.localPosition = new Vector3(
                    _originalPosition.x + x,
                    _originalPosition.y + y,
                    _originalPosition.z);
                _elapsedTime += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = _originalPosition;
        }

        private float GetValue()
        {
            return Random.Range(_minValue, _maxValue) * _magnitude;
        }
    }
}
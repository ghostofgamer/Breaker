using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CameraFiles
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField]private  float _duration = 0.5f;
        [SerializeField]private  float _magnitude = 0.5f;
        [SerializeField] private BrickExplosion[] _brickExplosions;
        
        private Vector3 _originalPosition;

        private void OnEnable()
        {
            foreach (var brick in _brickExplosions)
            {
                brick.Dead += Shake;
            }
        }

        private void OnDisable()
        {
            foreach (var brick in _brickExplosions)
            {
                brick.Dead -= Shake;
            }
        }

        private void Awake()
        {
            _originalPosition = transform.localPosition;
        }

        public void Shake()
        {
            StartCoroutine(ShakeCoroutine());
        }

        private IEnumerator ShakeCoroutine()
        {
            Vector3 originalPosition = transform.localPosition; // Сохраняем текущую позицию камеры
            float elapsed = 0.0f;

            while (elapsed < _duration)
            {
                float x = Random.Range(-1f, 1f) * _magnitude;
                float y = Random.Range(-1f, 1f) * _magnitude;

                transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);

                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = originalPosition;
            
            
            
            
            
            /*float elapsed = 0.0f;

            while (elapsed < _duration)
            {
                float x = Random.Range(-1f, 1f) * _magnitude;
                float y = Random.Range(-1f, 1f) * _magnitude;
                transform.localPosition = new Vector3(x, y, _originalPosition.z);
                elapsed += Time.deltaTime;

                yield return null;
            }

            transform.localPosition = _originalPosition;*/
        }
    }
}

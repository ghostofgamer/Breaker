using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Random = UnityEngine.Random;
using Vector3 = UnityEngine.Vector3;

public class Level3MoveBricks : MonoBehaviour
{
    /*
    public Transform pointA; // точка A
    public Transform pointB; // точка B
    public Transform center; // центр
    public float duration; // длительность движения

    private bool movingToPointA = true; // флаг для определения направления движения

    private void Start()
    {
        StartCoroutine(MoveOverTime());
    }

    private IEnumerator MoveOverTime()
    {
        while (true)
        {
            float elapsedTime = 0;
            Vector3 startPosition = transform.position;
            Vector3 endPosition = movingToPointA ? pointA.position : pointB.position;

            while (elapsedTime < duration)
            {
                float progress = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, endPosition, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition;
            movingToPointA = !movingToPointA;

            yield return new WaitForSeconds(1f); // пауза перед движением в обратном направлении

            elapsedTime = 0;
            startPosition = transform.position;
            endPosition = movingToPointA ? pointB.position : pointA.position;

            while (elapsedTime < duration)
            {
                float progress = elapsedTime / duration;
                transform.position = Vector3.Lerp(startPosition, endPosition, progress);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.position = endPosition;
            movingToPointA = !movingToPointA;
        }
    }*/
    
    [SerializeField] private  Transform _pointA;
    [SerializeField] private  Transform _pointB;
    [SerializeField] private Transform _center;
    [SerializeField] private float _rotationStart;
    [SerializeField] private float _endRotation;
    
    private bool _movingToPointB = true;
    private float _progress = 0.0f;

    private void Start()
    {
        StartCoroutine(Slerping());
    }

    private IEnumerator Slerping()
    {
        while (true)
        {
            float _elapsedTime = 0;
            float duration = 5;
            
            while (_elapsedTime < duration)
            {
                _elapsedTime += Time.deltaTime;
                float progress = _elapsedTime / duration;
                transform.position = Vector3.Slerp(_pointA.position - _center.position,
                    _pointB.position - _center.position,
                    progress) + _center.position;
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, _rotationStart, 0),
                    Quaternion.Euler(0, _endRotation, 0), progress);
                yield return null;
            }

            float randomPause = Random.Range(0.1f, 0.5f);
            yield return new WaitForSeconds(randomPause);

            float elapsedTime = 0;
            float _duration = 5;

            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;
                float progress = elapsedTime / _duration;
                transform.position = Vector3.Slerp(_pointB.position - _center.position,
                    _pointA.position - _center.position,
                    progress) + _center.position;
                transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, _endRotation, 0),
                    Quaternion.Euler(0, _rotationStart, 0), progress);
                yield return null;
            }
        }
    }
}
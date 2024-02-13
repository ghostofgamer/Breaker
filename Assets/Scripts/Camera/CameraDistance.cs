using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDistance : MonoBehaviour
{
    private float _distance = 15f;
    private float _lerpDuration = 1f;
    private Vector3 _targetPosition;
    private bool _isLerping = false;
    private float _timeElapsed;
    private Vector3 _initialPosition;

    void Start()
    {
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (_isLerping)
        {
            _timeElapsed += Time.deltaTime;
            float lerpProgress = _timeElapsed / _lerpDuration;

            transform.position = Vector3.Lerp(_initialPosition, _targetPosition, lerpProgress);

            if (lerpProgress >= 1f)
                _isLerping = false;
        }
    }

    public void MoveCameraToTarget(Transform target)
    {
        _targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z - _distance);
        _initialPosition = transform.position;
        _timeElapsed = 0f;
        _isLerping = true;
    }
}
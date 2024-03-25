using System.Collections;
using System.Collections.Generic;
using PlayerFiles.PlatformaContent;
using UnityEngine;

public class CyclicalMovement : MonoBehaviour
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
        while (true)
        {
            Vector3 targetPosition = _movingToStartPosition
                ? new Vector3(transform.position.x, transform.position.y, _startZPosition)
                : new Vector3(transform.position.x, transform.position.y, _startZPosition + _movementDistance);

            transform.position =
                Vector3.MoveTowards(transform.position, targetPosition, _movementSpeed * Time.deltaTime);

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

    private void SetTargetPosition(float zPosition)
    {
        _targetPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
        Debug.Log(_targetPosition);
    }
}
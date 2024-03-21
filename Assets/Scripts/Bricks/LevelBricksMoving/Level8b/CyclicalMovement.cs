using System.Collections;
using System.Collections.Generic;
using PlayerFiles.PlatformaContent;
using UnityEngine;

public class CyclicalMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 1f;
    [SerializeField] private float _rotateSpeed = 1f;
    [SerializeField] private float _movementDistance = 2f;
    [SerializeField] private PlatformaMover _platformaMover;

    private float _startZPosition;
    private Vector3 _targetPosition;
    private float _directionRotate;

    private void Start()
    {
        _startZPosition = transform.position.z;
        StartCoroutine(MoveCyclically());
    }

    private IEnumerator MoveCyclically()
    {
        while (true)
        {
            transform.position =
                Vector3.MoveTowards(transform.position, _targetPosition, _movementSpeed * Time.deltaTime);

            transform.Rotate(0, _directionRotate * _rotateSpeed, 0);

            if (transform.position == _targetPosition)
            {
                if (_targetPosition.z == _startZPosition + _movementDistance)
                {
                    SetTargetPosition(_startZPosition);
                }
                else
                {
                    SetTargetPosition(_startZPosition + _movementDistance);
                }
            }
        }


        yield return null;

        /*while (true)
        {
            // Движение вперед
            for (float z = _startZPosition; z < _startZPosition + _movementDistance; z += Time.deltaTime * _movementSpeed)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, z);
                yield return null;
            }

            // Движение назад
            for (float z = _startZPosition + _movementDistance; z > _startZPosition; z -= Time.deltaTime * _movementSpeed)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, z);
                yield return null;
            }
        }*/
    }

    private void SetTargetPosition(float zPosition)
    {
        _targetPosition = new Vector3(transform.position.x, transform.position.y, zPosition);
    }
}
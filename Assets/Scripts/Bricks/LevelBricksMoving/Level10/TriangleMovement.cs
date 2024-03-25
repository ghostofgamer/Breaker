using System;
using System.Collections;
using System.Collections.Generic;
using PlayerFiles.PlatformaContent;
using UnityEngine;

public class TriangleMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    [SerializeField] private float _moveStep;

    private void Update()
    {
        float targetX = transform.position.x + (_platformaMover.DirectionX * _movementSpeed * Time.deltaTime);
        targetX = Mathf.Clamp(targetX, _minX, _maxX);

        transform.position = Vector3.MoveTowards(transform.position,
            new Vector3(targetX, transform.position.y, transform.position.z), _moveStep * Time.deltaTime);
    }
}
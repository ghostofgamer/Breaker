using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatformaMover : MonoBehaviour
{
    [SerializeField] private Transform _originalPlatform;

    private Vector3 initialOffset; // Начальное смещение относительно оригинальной платформы
    private Vector3 initialPosition;

    void Start()
    {
        // initialOffset = transform.position - _originalPlatform.position;
        /*initialPosition = transform.position;
        Vector3 position = new Vector3(_originalPlatform.position.x + 7f, _originalPlatform.position.y,
            _originalPlatform.position.z);
        transform.position = position;*/
    }

    /*void Update()
    {
        transform.position = -(_originalPlatform.position - initialOffset);
        /*Vector3 newPosition = new Vector3(
            -(_originalPlatform.position.x - initialPosition.x) + _originalPlatform.position.x,
            transform.position.y,
            transform.position.z
        );

        // Обновляем позицию зеркальной платформы
        transform.position = newPosition;#1#
    }*/
    private void Update()
    {
        if (_originalPlatform != null)
            transform.position = new Vector3(-_originalPlatform.position.x, _originalPlatform.position.y,
                _originalPlatform.position.z);
    }

    public void SetPlatform(Transform platforma)
    {
        _originalPlatform = platforma;
    }
}
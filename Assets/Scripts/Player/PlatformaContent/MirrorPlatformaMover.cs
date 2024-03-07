using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatformaMover : MonoBehaviour
{
    [SerializeField] private Transform _originalPlatform;

    private void Update()
    {
        if (_originalPlatform != null)
            transform.position = new Vector3(-_originalPlatform.position.x, _originalPlatform.position.y,
                _originalPlatform.position.z);
    }
}
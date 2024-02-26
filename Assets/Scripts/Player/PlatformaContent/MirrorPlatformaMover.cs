using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorPlatformaMover : MonoBehaviour
{
    [SerializeField] private Transform _originalPlatform;

    /*private Vector3 _initialOffset;
    private Vector3 _initialPosition;*/

    private void Update()
    {
        if (_originalPlatform != null)
            transform.position = new Vector3(-_originalPlatform.position.x, _originalPlatform.position.y,
                _originalPlatform.position.z);
    }

    /*public void SetPlatform(Transform platforma)
    {
        _originalPlatform = platforma;
    }*/
}
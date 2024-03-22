using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FovChanger : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private int _fov = 55;
    
    private void Start()
    {
        if (!Application.isMobilePlatform)
        {
            Debug.Log("ФОВ");
            _camera.fieldOfView = _fov;
        }
    }
}

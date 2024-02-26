using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Capsula : MonoBehaviour
{
    private Quaternion originalRotation;
    private Vector3 originalLocalRotation;
    private bool _isSelected = false;
    private Quaternion targetRotation;
    private Quaternion _originalRotation;

    private bool _rotate;

    void Start()
    {
        originalRotation = transform.rotation;
        // originalLocalRotation = transform.localRotation;
        // originalLocalRotation = transform.localEulerAngles;
        // targetRotation = originalRotation * Quaternion.Euler(45, 0, 0);
    }

    void Update()
    {
        if (_isSelected)
        {
            if (!_rotate)
            {
                transform.rotation = Quaternion.Euler(0, 0, 35);
                _rotate = true;
            }

            Quaternion targetRotation = Quaternion.Euler(0, 0, 35);

            /*if (transform.rotation != targetRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * 30f);
            }*/

            transform.Rotate(0, 65 * Time.deltaTime, 0, Space.World);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 10f);
            _rotate = false;
        }
    }

    public void StartRotate(bool selected)
    {
        _isSelected = selected;
    }

    /*
    private void Update()
    {
        // transform.rotation = Quaternion.Euler(0,0f,-45f);
        transform.Rotate(0, 150 * Time.deltaTime, 0, Space.World);
    }
    */
}
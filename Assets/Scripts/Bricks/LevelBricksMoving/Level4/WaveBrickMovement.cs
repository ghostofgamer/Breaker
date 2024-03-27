using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBrickMovement : MonoBehaviour
{
    private float _speed = 3f;
    private float _amplitude = 2.3f;
    private float _frequency = 3f;
    private Vector3 initialPosition;
    private float _zPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        _zPosition = initialPosition.z + Mathf.Sin(Time.time * _speed + transform.position.x * _frequency) * _amplitude;
        transform.position = new Vector3(transform.position.x, transform.position.y, _zPosition);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateRotate : MonoBehaviour
{
    public float maxSpeed = 100.0f;
    public float accelerationTime = 2.0f;

    private float currentSpeed;
    private float acceleration;

    private void Start()
    {
        acceleration = maxSpeed / accelerationTime;
    }

    public void StartRotation()
    {
         currentSpeed = 0;
        enabled = true;
    }

    public void StopRotation()
    {
        enabled = false;
    }

    private void Update()
    {
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }

        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }
}

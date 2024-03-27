using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementState
{
    Accelerating,
    Holding,
    Decelerating,
    Pausing
}

public class TestLevel5b : MonoBehaviour
{
    public float maxRotationSpeed;
    public float rotationAccelerationTime;
    public float rotationDecelerationTime;
    public float holdTime;
    public float pauseTime;

    private float currentSpeed;
    private float accelerationFactor;
    private float decelerationFactor;
    private float timer;
    private int state;

    void Start()
    {
        accelerationFactor = maxRotationSpeed / rotationAccelerationTime;
        decelerationFactor = maxRotationSpeed / rotationDecelerationTime;
        state = (int) MovementState.Accelerating;
    }

    void Update()
    {
        switch ((MovementState) state)
        {
            case MovementState.Accelerating:
                currentSpeed += accelerationFactor * Time.deltaTime;
                if (currentSpeed >= maxRotationSpeed)
                {
                    currentSpeed = maxRotationSpeed;
                    state = (int) MovementState.Holding;
                    timer = 0;
                }

                break;
            case MovementState.Holding:
                timer += Time.deltaTime;
                if (timer >= holdTime)
                {
                    state = (int) MovementState.Decelerating;
                }

                break;
            case MovementState.Decelerating:
                currentSpeed -= decelerationFactor * Time.deltaTime;
                if (currentSpeed <= 0)
                {
                    currentSpeed = 0;
                    state = (int) MovementState.Pausing;
                    timer = 0;
                }

                break;
            case MovementState.Pausing:
                timer += Time.deltaTime;
                if (timer >= pauseTime)
                {
                    state = (int) MovementState.Accelerating;
                }

                break;
        }

        // Apply the calculated speed to the object's movement.
        transform.rotation = Quaternion.Euler(0, currentSpeed * Time.deltaTime, 0) * transform.rotation;
    }
}
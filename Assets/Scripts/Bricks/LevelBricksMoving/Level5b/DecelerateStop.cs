using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecelerateStop : MonoBehaviour
{
    public float decelerationTime = 2.0f;

    private float currentSpeed;
    private float deceleration;

    public void StartDeceleration(float startSpeed)
    {
        enabled = true;
        currentSpeed = startSpeed;
        deceleration = currentSpeed / decelerationTime;
    }

    private void Update()
    {
        if (currentSpeed > 0.0f)
        {
            currentSpeed -= deceleration * Time.deltaTime;
        }
        else
        {
            enabled = false;
        }

        transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }
}

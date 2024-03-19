using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialRotationControllerLevel5b : MonoBehaviour
{
    public GameObject[] objectsToRotate;
    public float startDelay;
    public float accelerationTime;
    public float maxSpeed;
    public float decelerationTime;

    private float[] speeds;
    private float targetSpeed;
    private float acceleration;
    private float deceleration;
    private int currentObjectIndex;
    private bool isAccelerating;

    void Start()
    {
        speeds = new float[objectsToRotate.Length];
        targetSpeed = maxSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }

    void BeginRotation()
    {
        if (currentObjectIndex < objectsToRotate.Length)
        {
            speeds[currentObjectIndex] = 0;
            isAccelerating = true;
            currentObjectIndex++;
        }
        else
        {
            isAccelerating = false;
            InvokeRepeating("StopRotation", decelerationTime, decelerationTime);
            CancelInvoke("BeginRotation");
        }
    }

    void StopRotation()
    {
        if (currentObjectIndex > 0)
        {
            currentObjectIndex--;
            speeds[currentObjectIndex] = maxSpeed;
        }
        else
        {
            currentObjectIndex = 0;
            CancelInvoke("StopRotation");
            Invoke("ResetAndStartRotation", startDelay);
        }
    }

    void ResetAndStartRotation()
    {
        speeds = new float[objectsToRotate.Length];
        isAccelerating = true;
        currentObjectIndex = 0;
        CancelInvoke("BeginRotation");
        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }

    void Update()
    {
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            if (isAccelerating && speeds[i] < targetSpeed && i < currentObjectIndex)
            {
                speeds[i] += acceleration * Time.deltaTime;
            }
            else if (!isAccelerating && speeds[i] > 0 && i < currentObjectIndex)
            {
                speeds[i] -= deceleration * Time.deltaTime;
            }
            else if (!isAccelerating && speeds[i] < targetSpeed && i < currentObjectIndex)
            {
                speeds[i] = 0;
            }

            objectsToRotate[i].transform.Rotate(Vector3.up, speeds[i] * Time.deltaTime);
        }
    }
    
    
    
    
    
    
    
        /*public GameObject[] objectsToRotate;
    public float startDelay;
    public float accelerationTime;
    public float maxSpeed;
    public float decelerationTime;

    private float[] speeds;
    private float targetSpeed;
    private float acceleration;
    private float deceleration;
    private int currentObjectIndex;
    private bool isAccelerating;

    void Start()
    {
        speeds = new float[objectsToRotate.Length];
        targetSpeed = maxSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }

    void BeginRotation()
    {
        if (currentObjectIndex < objectsToRotate.Length)
        {
            Debug.Log("BeginRotationIF");
            speeds[currentObjectIndex] = 0;
            isAccelerating = true;
            currentObjectIndex++;
        }
        else
        {
            Debug.Log("BeginRotationElse");
            isAccelerating = false;
            InvokeRepeating("StopRotation", decelerationTime, decelerationTime);
            CancelInvoke("BeginRotation");
        }
    }*/

    
    
    
    
    
    
    
    
    /*void StopRotation()
    {
        if (currentObjectIndex > 1)
        {
            Debug.Log("StopRotationIF");
            currentObjectIndex--;
            speeds[currentObjectIndex - 1] = maxSpeed;
        }
        else
        {
            Debug.Log("StopRotationElse");
            currentObjectIndex = 0;
            speeds[currentObjectIndex] = maxSpeed;
            CancelInvoke("StopRotation");
            InvokeRepeating("BeginRotation", startDelay, startDelay);
        }
    }*/
    
    /*void StopRotation()
    {
        if (currentObjectIndex > 0)
        {
            currentObjectIndex--;
        }
        else
        {
            currentObjectIndex = 0;
            CancelInvoke("StopRotation");
            Invoke("ResetAndStartRotation", startDelay);
        }
    }

    void ResetAndStartRotation()
    {
        speeds = new float[objectsToRotate.Length];
        isAccelerating = true;
        currentObjectIndex = 0;
        CancelInvoke("BeginRotation");
        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }

    void Update()
    {
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            if (isAccelerating && speeds[i] < targetSpeed && i < currentObjectIndex)
            {
                Debug.Log("1");
                speeds[i] += acceleration * Time.deltaTime;
            }
            else if (!isAccelerating && speeds[i] > 0 && i < currentObjectIndex)
            {
                Debug.Log("2");
                speeds[i] -= deceleration * Time.deltaTime;
            }

            objectsToRotate[i].transform.Rotate(Vector3.up, speeds[i] * Time.deltaTime);
        }
    }*/
    
    
    
    
    
    
    
     /*public GameObject[] objectsToRotate;
    public float startDelay;
    public float accelerationTime;
    public float maxSpeed;
    public float decelerationTime;

    private float[] speeds;
    private float targetSpeed;
    private float acceleration;
    private float deceleration;
    private int currentObjectIndex;
    private bool isAccelerating;

    void Start()
    {
        speeds = new float[objectsToRotate.Length];
        targetSpeed = maxSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;

        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }

    void BeginRotation()
    {
        if (currentObjectIndex < objectsToRotate.Length)
        {
            speeds[currentObjectIndex] = 0;
            isAccelerating = true;
            currentObjectIndex++;
        }
        else
        {
            isAccelerating = false;
            InvokeRepeating("StopRotation", decelerationTime, decelerationTime);
            CancelInvoke("BeginRotation");
        }
    }

    void StopRotation()
    {
        if (currentObjectIndex > 0)
        {
            currentObjectIndex--;
        }
        else
        {
            currentObjectIndex = 0;
            CancelInvoke("StopRotation");
            Invoke("ResetAndStartRotation", startDelay);
        }
    }
    
    void ResetAndStartRotation()
    {
        speeds = new float[objectsToRotate.Length];
        isAccelerating = true;
        currentObjectIndex = 0;
        InvokeRepeating("BeginRotation", startDelay, startDelay);
    }
    
    /*void StopRotation()
    {
        if (currentObjectIndex > 1)
        {
            currentObjectIndex--;
            speeds[currentObjectIndex - 1] = maxSpeed;
        }
        else
        {
            currentObjectIndex = 0;
            speeds[currentObjectIndex] = maxSpeed;
            CancelInvoke("StopRotation");
            InvokeRepeating("BeginRotation", startDelay, startDelay);
        }
    }#1#

    void Update()
    {
        for (int i = 0; i < objectsToRotate.Length; i++)
        {
            if (isAccelerating && speeds[i] < targetSpeed && i < currentObjectIndex)
            {
                speeds[i] += acceleration * Time.deltaTime;
            }
            else if (!isAccelerating && speeds[i] > 0 && i < currentObjectIndex)
            {
                speeds[i] -= deceleration * Time.deltaTime;
            }
            /* else if (!isAccelerating && speeds[i] > 0 && i < currentObjectIndex)
            {
                speeds[i] -= deceleration * Time.deltaTime;
            }#1#

            objectsToRotate[i].transform.Rotate(Vector3.up, speeds[i] * Time.deltaTime);
        }
    }*/
    
    
    
    /*public GameObject[] objectsToRotate;
    public float startDelay;
    public float accelerationTime;
    public float maxSpeed;
    public float decelerationTime;

    private int currentObjectIndex;
    private float currentSpeed;
    private float targetSpeed;
    private float acceleration;
    private float deceleration;
    private bool isAccelerating;

    void Start()
    {
        Invoke("BeginRotation", startDelay);
        targetSpeed = maxSpeed;
        acceleration = maxSpeed / accelerationTime;
        deceleration = maxSpeed / decelerationTime;
    }

    void BeginRotation()
    {
        isAccelerating = true;
    }

    void Update()
    {
        if (isAccelerating)
        {
            currentSpeed += acceleration * Time.deltaTime;
            
            if (currentSpeed >= targetSpeed)
            {
                currentSpeed = targetSpeed;
                isAccelerating = false;
            }
        }
        else
        {
            currentSpeed -= deceleration * Time.deltaTime;
            if (currentSpeed <= 0)
            {
                currentSpeed = 0;
                if (currentObjectIndex < objectsToRotate.Length - 1)
                {
                    currentObjectIndex++;
                    isAccelerating = true;
                }
                else
                {
                    currentObjectIndex = objectsToRotate.Length - 1;
                    Invoke("ReverseRotation", decelerationTime);
                }
            }
        }

        objectsToRotate[currentObjectIndex].transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
    }

    void ReverseRotation()
    {
        if (currentObjectIndex >= 0)
        {
            isAccelerating = false;
            currentObjectIndex--;
        }
        else
        {
            currentObjectIndex = 0;
            Invoke("BeginRotation", startDelay);
        }
    }*/
}

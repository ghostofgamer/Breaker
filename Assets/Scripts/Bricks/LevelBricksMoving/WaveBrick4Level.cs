using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveBrick4Level : MonoBehaviour
{
    /*public Transform target1;
    public Transform target2;
    public float speed = 1.0f;
    public float amplitude = 0.5f;
    public float frequency = 1.0f;

    private Vector3 initialPosition;
    private Vector3 destination;
    private float progress;

    void Start()
    {
        initialPosition = transform.position;
        destination = new Vector3(initialPosition.x, initialPosition.y, target1.position.z);
    }

    void Update()
    {
        progress += Time.deltaTime * speed;
        float t = Mathf.PingPong(progress, 1.0f);

        Vector3 targetPosition = Vector3.Lerp(destination, new Vector3(initialPosition.x, initialPosition.y, target2.position.z), t);
        float z = targetPosition.z + Mathf.Sin(Time.time * speed + transform.position.x * frequency) * amplitude;

        transform.position = new Vector3(initialPosition.x, initialPosition.y, z);

        if (transform.position.z == target2.position.z)
        {
            Vector3 temp = target1.position;
            target1.position = target2.position;
            target2.position = temp;
            destination = new Vector3(initialPosition.x, initialPosition.y, target1.position.z);
        }
    }*/
    
    
    
    
    
    
    public float speed = 1.0f;
    public float amplitude = 0.5f;
    public float frequency = 1.0f;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float z = initialPosition.z + Mathf.Sin(Time.time * speed + transform.position.x * frequency) * amplitude;
        transform.position = new Vector3(transform.position.x, transform.position.y, z);
    }
}

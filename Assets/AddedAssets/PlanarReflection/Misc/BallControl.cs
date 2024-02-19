﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody[] balls;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(Rigidbody rb in balls)
            {
                Vector3 randomDir = UnityEngine.Random.onUnitSphere * UnityEngine.Random.Range(10,30);
                randomDir.y = 0;
                rb.velocity = randomDir;
                rb.AddForce(transform.up * UnityEngine.Random.Range(100, 1000));
            }
        }
    }
}

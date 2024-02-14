using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class BuffMover : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(-Vector3.forward * 10 * Time.deltaTime);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(Vector3.up * 30f * Time.deltaTime);
    }
}

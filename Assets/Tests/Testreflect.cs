using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testreflect : MonoBehaviour
{
    public Transform normal;
    public Transform vector;
    public Transform result;

    private void Update()
    {
        result.position = Vector3.Reflect(vector.forward, normal.forward)*10;
        Debug.DrawLine(normal.position,normal.forward*10, Color.green);
        Debug.DrawLine(vector.position,vector.forward*10, Color.red);
        Debug.DrawLine(normal.position,result.position, Color.blue);
    }
}

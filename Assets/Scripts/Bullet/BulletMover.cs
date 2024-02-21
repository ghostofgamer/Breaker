using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}

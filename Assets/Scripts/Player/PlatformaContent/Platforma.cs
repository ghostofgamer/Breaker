using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforma : Player
{
    public Vector3 StartSize { get; private set; }

    private void Start()
    {
        StartSize = transform.localScale;
    }
}
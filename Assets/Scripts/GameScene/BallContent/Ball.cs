using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : Player
{
    public Vector3 StartSize { get; private set; }

    private void Start()
    {
        StartSize = transform.localScale;
    }
}

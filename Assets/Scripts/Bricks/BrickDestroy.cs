using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : Brick
{
    public override void Die()
    {
        Destroy();
    }
}
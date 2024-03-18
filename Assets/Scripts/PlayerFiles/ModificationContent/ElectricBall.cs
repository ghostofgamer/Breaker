using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using UnityEngine;

public class ElectricBall : MonoBehaviour
{
    public void DestroyBrick(Brick brick)
    {
        if(brick.GetComponent<BrickExplosion>())
        {
            brick.GetComponent<BrickExplosion>().Detonate();
        }
        else
        {
            brick.Die();
        }
    }
}

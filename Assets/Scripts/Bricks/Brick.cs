using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brick : MonoBehaviour
{
    [SerializeField] protected BrickCounter BrickCounter;
    [SerializeField] private int _reward;

    public int Reward => _reward;

    public void Init(BrickCounter brickCounter)
    {
        BrickCounter = brickCounter;
    }

    public abstract void Die();
}

using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : Player
{
    [SerializeField] private BrickCounter _brickCounter;

    private BallMover _ballMover;
    
    public event UnityAction Die;

    private void Start()
    {
        _ballMover = GetComponent<BallMover>();
    }
    
    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += StopMove;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= StopMove;
    }

    public void StopMove()
    {
        _ballMover.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    protected void Lost()
    {
        Die?.Invoke();
    }
}
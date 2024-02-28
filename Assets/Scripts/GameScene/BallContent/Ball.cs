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
    public bool IsMoving { get; private set; }

    public event UnityAction Die;

    private void Start()
    {
        _ballMover = GetComponent<BallMover>();
        StopMove();
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
        IsMoving = false;
        _ballMover.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public void SetMove(bool flag)
    {
        IsMoving = flag;
        _ballMover.enabled = flag;
        GetComponent<Rigidbody>().isKinematic = !flag;
        gameObject.transform.parent = null;
    }

    protected void Lost()
    {
        Die?.Invoke();
    }
}
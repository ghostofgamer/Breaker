using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class Ball : Player
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private PlatformaMover _platformaMover;
    [SerializeField] private Transform _enviropment;

    private BallMover _ballMover;
    public bool IsMoving { get; private set; }
    public Transform StartPosition => _startPosition;
    public PlatformaMover PlatformaMover => _platformaMover;

    public event UnityAction Die;

    private bool _isWin;

    private void Start()
    {
        _ballMover = GetComponent<BallMover>();
        StopMove();
    }

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += StopMove;
        _brickCounter.AllBrickDestory += SetParent;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= StopMove;
        _brickCounter.AllBrickDestory -= SetParent;
    }

    private void Update()
    {
        if (!IsMoving && !_isWin)
        {
            transform.position = new Vector3(_platformaMover.transform.position.x, _platformaMover.transform.position.y,
                _platformaMover.transform.position.z + 3f);
        }
    }

    public void StopMove()
    {
        IsMoving = false;
        _ballMover.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    private void SetParent()
    {
        _isWin = true;
        transform.parent = _enviropment;
    }

    public void SetMove(bool flag, float DirectionX)
    {
        IsMoving = flag;
        _ballMover.enabled = flag;
        GetComponent<Rigidbody>().isKinematic = !flag;
        // gameObject.transform.parent = null;
        _ballMover.SetStartDirection(new Vector3(DirectionX, 0, 1).normalized);
        // Debug.Log("STARTDIRECTMOVE   " + new Vector3(DirectionX,0,1).normalized);
    }

    protected void Lost()
    {
        Die?.Invoke();
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using Statistics;
using UnityEngine;

public class ParentsChanger : MonoBehaviour
{
    [SerializeField] private Transform _parentTarget;
    [SerializeField] private Transform _enviropment;
    [SerializeField] private Brick[] _bricks;
    [SerializeField] private Brick[] _bricksEternal;
    [SerializeField] private Brick _brick;
    [SerializeField] private BrickCounter _brickCounter;

    private void OnEnable()
    {
        if (_brick != null)
            _brick.Dead += ChangeParent;

        if (_brickCounter != null)
            _brickCounter.AllBrickDestroy += SetParentEnviropment;
    }

    private void OnDisable()
    {
        if (_brick != null)
            _brick.Dead -= ChangeParent;

        if (_brickCounter != null)
            _brickCounter.AllBrickDestroy += SetParentEnviropment;
    }

    private void ChangeParent()
    {
        foreach (var brick in _bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = false;
            brick.transform.parent = _parentTarget;
        }
    }

    private void SetParentEnviropment()
    {
        if (_bricksEternal.Length <= 0)
            return;

        foreach (var brick in _bricksEternal)
        {
            brick.transform.parent = _enviropment;
        }
    }
}
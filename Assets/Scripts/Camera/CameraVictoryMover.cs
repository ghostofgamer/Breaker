using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraVictoryMover : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BrickCounter _brickCounter;

    private WaitForSeconds _waitForSeconds= new WaitForSeconds(1f);
    private string _victory = "Victory";
    
    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += Move;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= Move;
    }

    private void Move()
    {
        StartCoroutine(OnMove());
    }

    private IEnumerator OnMove()
    {
        yield return _waitForSeconds;
        _animator.SetTrigger(_victory);
    }
}
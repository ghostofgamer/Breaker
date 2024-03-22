using System;
using System.Collections;
using System.Collections.Generic;
using Statistics;
using UnityEngine;

public class BrickRingController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private GameObject[] _blocks;

    private WaitForSeconds _starWait = new WaitForSeconds(1.5f);
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += Stop;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= Stop;
    }

    private void Start()
    {
        _coroutine = StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        yield return _starWait;

        while (true)
        {
            // ChangeActivations(false);
            _animator.Play("BrickRing");
            yield return _waitForSeconds;
            _animator.Play("BrickRingEnd");
            // StartCoroutine(SetValue(true));
            yield return _waitForSeconds;
        }
    }

    private void Stop()
    {
        StopCoroutine(_coroutine);
        enabled = false;
    }

    private IEnumerator SetValue(bool flag)
    {
        yield return new WaitForSeconds(1f);
        ChangeActivations(flag);
    }

    private void ChangeActivations(bool flag)
    {
        foreach (var block in _blocks)
        {
            block.GetComponent<BoxCollider>().enabled = flag;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdditionalLaser : MonoBehaviour
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private Effect _effect;
    [SerializeField] private BallTrigger _ballTrigger;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(6f);
    private Coroutine _coroutine;

    private void OnEnable()
    {
        _brickCounter.BricksDestructionHelp += SpawnLaser;
        _brickCounter.AllBrickDestory += StopCorutine;
        _ballTrigger.Dying += StopCorutine;
    }

    private void OnDisable()
    {
        _brickCounter.BricksDestructionHelp -= SpawnLaser;
        _brickCounter.AllBrickDestory -= StopCorutine;
        _ballTrigger.Dying += StopCorutine;
    }

    private void StopCorutine()
    {
        StopCoroutine(_coroutine);
    }

    private void SpawnLaser()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(StartSpawnlaser());
    }

    private IEnumerator StartSpawnlaser()
    {
        while (true)
        {
            Instantiate(_effect, transform);
            yield return _waitForSeconds;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDestroyer : MonoBehaviour
{
    [SerializeField] private float _delay;

    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _waitForSeconds = new WaitForSeconds(_delay);
        StartCoroutine(SetActiveChanged());
    }

    private IEnumerator SetActiveChanged()
    {
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectApplier : MonoBehaviour
{
    [SerializeField] private TestPlatformaMover _testPlatformaMover;

    private int _coefficien = 1;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public void Apply(BuffType buffType)
    {
        switch (buffType)
        {
            case BuffType.PaddleGrow:
                PaddleGrow();
                break;
        }
    }

    private void PaddleGrow()
    {
        if (_testPlatformaMover.GetComponent<Platforma>().TryApplyEffect(BuffType.PaddleGrow))
        {
           StartCoroutine(OnPaddleGrow()); 
        }
    }

    private IEnumerator OnPaddleGrow()
    {
        var localScale = _testPlatformaMover.transform.localScale;
        Vector3 target = new Vector3(localScale.x + _coefficien, localScale.y + _coefficien,
            localScale.z + _coefficien);
        _testPlatformaMover.transform.localScale = target;
        yield return _waitForSeconds;
        _testPlatformaMover.transform.localScale = localScale;
        _testPlatformaMover.GetComponent<Platforma>().DeleteEffect(BuffType.PaddleGrow);
    }
}
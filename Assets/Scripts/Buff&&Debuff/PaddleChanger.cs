using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleChanger : MonoBehaviour
{
    [SerializeField] protected int _sizeChange;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

    public void PaddleCangeValue(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnPaddleShrink(platformaMover));
    }

    private IEnumerator OnPaddleShrink(PlatformaMover platformaMover)
    {
        var localScale = platformaMover.transform.localScale;
        Vector3 target = new Vector3(localScale.x/* + _sizeChange*/, localScale.y + _sizeChange,
            localScale.z /*+ _sizeChange*/);
        platformaMover.transform.localScale = target;
        yield return _waitForSeconds;
        // platformaMover.transform.localScale = localScale;
        platformaMover.transform.localScale = platformaMover.GetComponent<Platforma>().StartSize;
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }
}
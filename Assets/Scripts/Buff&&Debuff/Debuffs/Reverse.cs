using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public void ReversePaddleActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnReversePaddleActivated(platformaMover));
    }

    private IEnumerator OnReversePaddleActivated(PlatformaMover platformaMover)
    {
        platformaMover.SetReverse(true);
        yield return _waitForSeconds;
        platformaMover.SetReverse(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    } 
}

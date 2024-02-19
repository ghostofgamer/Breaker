using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLag : MonoBehaviour
{
    [SerializeField] private float _speedChanger;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public void PaddleLagActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnPaddleLagActivated(platformaMover));
    }

    private IEnumerator OnPaddleLagActivated(PlatformaMover platformaMover)
    {
        float startSpeed = platformaMover.Speed;
        platformaMover.SetValue(startSpeed/_speedChanger);
        yield return _waitForSeconds;
        platformaMover.SetValue(startSpeed);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    } 
}

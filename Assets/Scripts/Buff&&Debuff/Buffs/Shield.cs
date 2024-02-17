using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [SerializeField] private GameObject _shield;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    
    public void ShieldActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnShieldActivated(platformaMover));
    }

    private IEnumerator OnShieldActivated(PlatformaMover platformaMover)
    {
        _shield.SetActive(true);
        yield return _waitForSeconds;
        _shield.SetActive(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }
}

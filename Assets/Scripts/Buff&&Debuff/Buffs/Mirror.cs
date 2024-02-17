using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    [SerializeField] private Platforma _originalPlatforma;
    [SerializeField] private MirrorPlatformaMover _mirrorPlatforma;
    [SerializeField] private Transform _container;
    [SerializeField] protected BuffType _buffType;
    [SerializeField]private BuffApplier _buffApplier;
    [SerializeField]private DebuffApplier _debuffApplier;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    
    public void GetMirrorPlatform(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnGetMirrorPlatform(platformaMover));
    }

    private IEnumerator OnGetMirrorPlatform(PlatformaMover platformaMover)
    {
        var mirrorPlatforma = Instantiate(_mirrorPlatforma, _container);
        mirrorPlatforma.SetPlatform(_originalPlatforma.transform);
        mirrorPlatforma.GetComponent<PlatformaTrigger>().Init(_buffApplier, _debuffApplier);
        yield return _waitForSeconds;
        mirrorPlatforma.gameObject.SetActive(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }
}
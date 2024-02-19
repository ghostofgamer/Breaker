using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Mirror : Modification
{
    [SerializeField] private Platforma _originalPlatforma;
    [SerializeField] private MirrorPlatformaMover _mirrorPlatformaPrefab;
    [SerializeField] private Transform _container;
    [SerializeField]private BuffApplier _buffApplier;
    [SerializeField]private DebuffApplier _debuffApplier;
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private MirrorPlatformaMover _mirrorPlatforma;
    
    public override void ApplyModification(Player player)
    {
        if (Player.TryApplyEffect(this))
            StartCoroutine(OnGetMirrorPlatform());
    }

    public override void StopModification(Player player)
    {
        Stop(_mirrorPlatforma);
    }

    /*public void GetMirrorPlatform(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnGetMirrorPlatform(platformaMover));
    }*/

    private IEnumerator OnGetMirrorPlatform()
    {
        _mirrorPlatforma = Instantiate(_mirrorPlatformaPrefab, _container);
        _mirrorPlatforma.SetPlatform(_originalPlatforma.transform);
        _mirrorPlatforma.GetComponent<PlatformaTrigger>().Init(_buffApplier, _debuffApplier);
        yield return _waitForSeconds;
        Stop(_mirrorPlatforma);
        /*mirrorPlatforma.gameObject.SetActive(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);*/
    }

    private void Stop(MirrorPlatformaMover mirrorPlatformaMover)
    {
        mirrorPlatformaMover.gameObject.SetActive(false);
        Player.DeleteEffect(this);
    }
}
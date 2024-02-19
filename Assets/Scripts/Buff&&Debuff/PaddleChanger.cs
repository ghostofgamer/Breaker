using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleChanger : Modification
{
    [SerializeField] protected int _sizeChange;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);
    private Vector3 _standardScale;
    
    private void Start()
    {
        _standardScale = PlatformaMover.transform.localScale;
    }
    
    protected IEnumerator OnPaddleSizeChanger(PlatformaMover platformaMover)
    {
        Change(PlatformaMover);
        yield return _waitForSeconds;
        Reset(Player, PlatformaMover);
    }
    
    private void Change(PlatformaMover platformaMover)
    {
        // Vector3 target = new Vector3(_standardScale.x + _sizeChange, _standardScale.y + _sizeChange,
        //     _standardScale.z + _sizeChange);
        Vector3 target = new Vector3(_standardScale.x , _standardScale.y + _sizeChange,
            _standardScale.z);
        platformaMover.transform.localScale = target;
    }

    protected void Reset(Player player, PlatformaMover platformaMover)
    {
        platformaMover.transform.localScale = _standardScale;
        player.DeleteEffect(this);
    }
}
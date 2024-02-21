using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleChanger : Modification
{
    [SerializeField] protected int _sizeChange;

    private Vector3 _standardScale;

    protected override void Start()
    {
        base.Start();
        _standardScale = PlatformaMover.transform.localScale;
    }
    
    protected IEnumerator OnPaddleSizeChanger()
    {
        SetActive(true);
        Change();
        yield return WaitForSeconds;
        Reset();
        Player.DeleteEffect(this);
    }
    
    private void Change()
    {
        Vector3 target = new Vector3(_standardScale.x , _standardScale.y + _sizeChange,
            _standardScale.z);
        PlatformaMover.transform.localScale = target;
    }

    protected void Reset()
    {
        SetActive(false);
        PlatformaMover.transform.localScale = _standardScale;
    }
}
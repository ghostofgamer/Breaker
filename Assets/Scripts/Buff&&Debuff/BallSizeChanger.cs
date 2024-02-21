using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallSizeChanger : Modification
{
    [SerializeField] protected int _sizeChange;

    private Vector3 _standardScale;

    protected override void Start()
    {
        base.Start();
        _standardScale = BallPortalMover.transform.localScale;
    }

    protected IEnumerator OnBallChangeSize(BallPortalMover ballPortalMover)
    {
        SetActive(true);
        Change();
        yield return WaitForSeconds;
        Reset();
        Player.DeleteEffect(this);
    }

    private void Change()
    {
        Vector3 target = new Vector3(_standardScale.x + _sizeChange, _standardScale.y + _sizeChange,
            _standardScale.z + _sizeChange);
        BallPortalMover.transform.localScale = target;
        // BallPortalMover.SetRadius(_sizeChange);
    }

    protected void Reset()
    {
        SetActive(false);
        BallPortalMover.transform.localScale = _standardScale;
        // BallPortalMover.SetRadius(-_sizeChange);
    }
}
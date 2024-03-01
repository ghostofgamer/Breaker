using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallSizeChanger : Modification
{
    [SerializeField] protected float _sizeChange;

    [SerializeField]private Vector3 _standardScale;

    protected override void Start()
    {
        base.Start();
        // _standardScale = _ballMover.transform.localScale;
    }

    protected IEnumerator OnBallChangeSize(BallMover ballMover)
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
        _ballMover.transform.localScale = target;
        // BallPortalMover.SetRadius(_sizeChange);
    }

    protected void Reset()
    {
        SetActive(false);
        _ballMover.transform.localScale = _standardScale;
        // BallPortalMover.SetRadius(-_sizeChange);
    }
}
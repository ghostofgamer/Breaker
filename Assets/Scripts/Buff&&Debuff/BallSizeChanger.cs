using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallSizeChanger : Modification
{
    [SerializeField] protected int _sizeChange;
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);
    private Vector3 _standardScale;

    private void Start()
    {
        _standardScale = BallPortalMover.transform.localScale;
    }

    /*public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            StartCoroutine(OnBallChangeSize(BallPortalMover));
    }

    public override void StopModification(Player player)
    {
        // ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
        Reset(player, BallPortalMover);
        // player.DeleteEffect(this);
    }*/

    /*public void BallChangeSize(BallPortalMover ballController)
    {
        if (ballController.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnBallChangeSize(ballController));
    }*/

    protected IEnumerator OnBallChangeSize(BallPortalMover ballPortalMover)
    {
        Change(ballPortalMover);
        /*var localScale = ballController.transform.localScale;
        Vector3 target = new Vector3(localScale.x + _sizeChange, localScale.y + _sizeChange,
            localScale.z + _sizeChange);
        ballController.transform.localScale = target;*/
        yield return _waitForSeconds;
        Reset(Player, ballPortalMover);
        // ballController.GetComponent<Ball>().DeleteEffect(_buffType);
        // ballController.transform.localScale = localScale;
        /*ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
        ballController.GetComponent<Ball>().DeleteEffect(_buffType);*/
    }

    private void Change(BallPortalMover ballPortalMover)
    {
        // var localScale = ballController.transform.localScale;
        Vector3 target = new Vector3(_standardScale.x + _sizeChange, _standardScale.y + _sizeChange,
            _standardScale.z + _sizeChange);
        ballPortalMover.transform.localScale = target;
    }

    protected void Reset(Player player, BallPortalMover ballPortalMover)
    {
        ballPortalMover.transform.localScale = _standardScale;
        player.DeleteEffect(this);
    }
}
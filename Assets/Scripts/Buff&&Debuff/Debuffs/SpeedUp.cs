using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Modification
{
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(5f);
    private float _startSpeed;

    public override void ApplyModification(Player player)
    {
        if (Player.TryApplyEffect(this))
            StartCoroutine(OnSpeedUpActivated());
    }

    public override void StopModification(Player player)
    {
        Stop();
    }

    private void Stop()
    {
        BallPortalMover.SetValue(_startSpeed);
        Player.DeleteEffect(this);
    }

    /*public void SpeedUpActivated(BallPortalMover ballPortalMover)
    {
        if (ballPortalMover.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnSpeedUpActivated(ballPortalMover));
    }*/

    private IEnumerator OnSpeedUpActivated()
    {
        _startSpeed = BallPortalMover.Speed;
        BallPortalMover.SetValue(_startSpeed * 2);
        yield return _waitForSeconds;
        Stop();
        /*ballPortalMover.SetValue(_startSpeed);
        ballPortalMover.GetComponent<Ball>().DeleteEffect(_buffType);*/
    }
}
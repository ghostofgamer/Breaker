using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(5f);

    public void SpeedUpActivated(BallPortalMover ballPortalMover)
    {
        if (ballPortalMover.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnSpeedUpActivated(ballPortalMover));
    }

    private IEnumerator OnSpeedUpActivated(BallPortalMover ballPortalMover)
    {
        float _startSpeed = ballPortalMover.Speed;
        ballPortalMover.SetValue(_startSpeed*2);
        yield return _waitForSeconds;
        ballPortalMover.SetValue(_startSpeed);
        ballPortalMover.GetComponent<Ball>().DeleteEffect(_buffType);
    }
}
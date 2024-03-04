using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : Modification
{
    private float _startSpeed;

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnSpeedUpActivated());
            ShowNameEffect();
        }
    }

    public override void StopModification()
    {
        Stop();
    }

    private void Stop()
    {
        SetActive(false);
        _ballMover.SetValue(_startSpeed,false);
    }

    private IEnumerator OnSpeedUpActivated()
    {
        SetActive(true);
        _startSpeed = _ballMover.MinSpeed;
        _ballMover.SetValue(_startSpeed * 2,true);
        yield return WaitForSeconds;
        Stop();
        Player.DeleteEffect(this);
    }
}
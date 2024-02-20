using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLag : Modification
{
    [SerializeField] private float _speedChanger;

    private float _startSpeed;

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnPaddleLagActivated());
        }
    }

    public override void StopModification()
    {
        Stop();
    }

    private void Stop()
    {
        PlatformaMover.SetValue(_startSpeed);
    }

    private IEnumerator OnPaddleLagActivated()
    {
        _startSpeed = PlatformaMover.Speed;
        PlatformaMover.SetValue(_startSpeed / _speedChanger);
        yield return WaitForSeconds;
        Stop();
        Player.DeleteEffect(this);
    }
}
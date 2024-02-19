using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleLag : Modification
{
    [SerializeField] private float _speedChanger;
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    private float _startSpeed;
    
    public override void ApplyModification(Player player)
    {
        if (Player.TryApplyEffect(this))
            StartCoroutine(OnPaddleLagActivated());
    }

    public override void StopModification(Player player)
    {
        Stop();
    }

    private void Stop()
    {
        PlatformaMover.SetValue(_startSpeed);
        Player.DeleteEffect(this);
    }

    /*public void PaddleLagActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnPaddleLagActivated(platformaMover));
    }*/

    private IEnumerator OnPaddleLagActivated()
    {
        _startSpeed = PlatformaMover.Speed;
        PlatformaMover.SetValue(_startSpeed/_speedChanger);
        yield return _waitForSeconds;
        Stop();
        /*PlatformaMover.SetValue(_startSpeed);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);*/
    } 
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : Modification
{
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    
    public override void ApplyModification(Player player)
    {
        if (Player.TryApplyEffect(this))
            StartCoroutine(OnReversePaddleActivated());
    }

    public override void StopModification(Player player)
    {
        Stop();
    }

    private void Stop()
    {
        PlatformaMover.SetReverse(false);
        Player.DeleteEffect(this);
    }

    /*public void ReversePaddleActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnReversePaddleActivated(platformaMover));
    }*/

    private IEnumerator OnReversePaddleActivated()
    {
        PlatformaMover.SetReverse(true);
        yield return _waitForSeconds;
        Stop();
        /*platformaMover.SetReverse(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);*/
    } 
}

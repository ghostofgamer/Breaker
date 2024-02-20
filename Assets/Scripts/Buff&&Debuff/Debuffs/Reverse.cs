using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : Modification
{
    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if(Coroutine!=null)
                StopCoroutine(Coroutine);
            
            StartCoroutine(OnReversePaddleActivated());
        }
    }

    public override void StopModification()
    {
        Stop();
    }

    private void Stop()
    {
        PlatformaMover.SetReverse(false);
    }

    private IEnumerator OnReversePaddleActivated()
    {
        PlatformaMover.SetReverse(true);
        yield return WaitForSeconds;
        Stop();
        Player.DeleteEffect(this);
    } 
}

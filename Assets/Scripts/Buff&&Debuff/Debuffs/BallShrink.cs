using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShrink : BallSizeChanger
{
    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnBallChangeSize(BallPortalMover));
        }
    }

    public override void StopModification()
    {
        Reset();
    }
}
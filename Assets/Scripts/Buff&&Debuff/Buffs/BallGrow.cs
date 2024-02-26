using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrow : BallSizeChanger
{
    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnBallChangeSize(_ballMover));
        }
    }

    public override void StopModification()
    {
        Reset();
    }
}
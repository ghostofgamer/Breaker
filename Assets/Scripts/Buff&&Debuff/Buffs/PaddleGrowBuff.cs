using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleGrowBuff : PaddleChanger
{
    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if(Coroutine!=null)
                StopCoroutine(Coroutine);
            
            Coroutine = StartCoroutine(OnPaddleSizeChanger());
        }
    }

    public override void StopModification()
    {
        Reset();
    }
}

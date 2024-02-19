using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleShrinkBuff : PaddleChanger
{
    public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            StartCoroutine(OnPaddleSizeChanger(PlatformaMover));
    }

    public override void StopModification(Player player)
    {
        Reset(player, PlatformaMover);
    }
}

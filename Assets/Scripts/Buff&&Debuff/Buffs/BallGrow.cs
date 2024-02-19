using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGrow : BallSizeChanger
{
    public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            StartCoroutine(OnBallChangeSize(BallPortalMover));
    }

    public override void StopModification(Player player)
    {
        // ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
        Reset(player, BallPortalMover);
        // player.DeleteEffect(this);
    }
}

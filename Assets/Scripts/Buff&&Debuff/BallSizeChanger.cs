using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallSizeChanger : Modification
{
    [SerializeField] protected int _sizeChange;
    [SerializeField] protected BuffType _buffType;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.65f);

    protected override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(_buffType))
            StartCoroutine(OnBallChangeSize(BallController));
        /*if (ballController.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnBallChangeSize(ballController));*/
    }

    public override void StopModification(Player player)
    {
        // ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
        Reset(BallController);
        player.DeleteEffect(_buffType);
    }

    public void BallChangeSize(BallController ballController)
    {
        if (ballController.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnBallChangeSize(ballController));
    }

    private IEnumerator OnBallChangeSize(BallController ballController)
    {
        var localScale = ballController.transform.localScale;
        Vector3 target = new Vector3(localScale.x + _sizeChange, localScale.y + _sizeChange,
            localScale.z + _sizeChange);
        ballController.transform.localScale = target;
        yield return _waitForSeconds;
        Reset(ballController);
        ballController.GetComponent<Ball>().DeleteEffect(_buffType);
        // ballController.transform.localScale = localScale;
        /*ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
        ballController.GetComponent<Ball>().DeleteEffect(_buffType);*/
    }

    private void Reset(BallController ballController)
    {
        ballController.transform.localScale = ballController.GetComponent<Ball>().StartSize;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallSizeChanger : MonoBehaviour
{
    [SerializeField] protected int _sizeChange;
    [SerializeField] protected BuffType _buffType;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
    
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
        ballController.transform.localScale = localScale;
        ballController.GetComponent<Ball>().DeleteEffect(_buffType);
    }
}

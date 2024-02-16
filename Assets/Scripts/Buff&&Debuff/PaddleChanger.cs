using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PaddleChanger : MonoBehaviour
{
    [SerializeField] protected int _coefficien;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);

    public virtual void PaddleCangeValue(TestPlatformaMover testPlatformaMover)
    {
        if (testPlatformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnPaddleShrink(testPlatformaMover));
    }

    private IEnumerator OnPaddleShrink(TestPlatformaMover testPlatformaMover)
    {
        var localScale = testPlatformaMover.transform.localScale;
        Vector3 target = new Vector3(localScale.x + _coefficien, localScale.y + _coefficien,
            localScale.z + _coefficien);
        testPlatformaMover.transform.localScale = target;
        yield return _waitForSeconds;
        testPlatformaMover.transform.localScale = localScale;
        testPlatformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }
}
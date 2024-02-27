using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EndScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private Animator _animator;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    public virtual void Open()
    {
        ChangeValue(1, true, true);
        _animator.Play("ScreenOpen");
    }

    public virtual void Close()
    {
        StartCoroutine(ScreenDeactivation());
    }

    private void ChangeValue(int alpha, bool interactable, bool blockRaycast)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = interactable;
        _canvasGroup.blocksRaycasts = blockRaycast;
    }

    private IEnumerator ScreenDeactivation()
    {
        _animator.Play("ScreenClose");
        yield return _waitForSeconds;
        ChangeValue(0, false, false);
    }
}
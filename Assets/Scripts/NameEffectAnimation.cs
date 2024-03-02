using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameEffectAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CanvasGroup _canvasGroup;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private Coroutine _coroutine;

    public void Show()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ShowAnimation());
    }

    private IEnumerator ShowAnimation()
    {
        SetValue(1);
        _animator.Play("EffectNameAnimation");
        yield return _waitForSeconds;
        SetValue(0);
    }

    private void SetValue(int alpha)
    {
        _canvasGroup.alpha = alpha;
    }
}
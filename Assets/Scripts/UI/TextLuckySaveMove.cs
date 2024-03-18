using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLuckySaveMove : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private Coroutine _coroutine;

    public void Play()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(PlayMove());
    }

    private IEnumerator PlayMove()
    {
        _animator.Play("EffectNameAnimation");
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}

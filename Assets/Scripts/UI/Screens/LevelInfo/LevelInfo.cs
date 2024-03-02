using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _cubePositionInfo;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private Coroutine _coroutineOpen;
    private Coroutine _coroutineClose;

    private void Start()
    {
        SetActive(0, false);
    }

    public void Open()
    {
        if(_coroutineOpen!=null)
            StopCoroutine(_coroutineOpen);
        
        StartCoroutine(OpenScreen());
    }

    public void Close()
    {
        if(_coroutineClose!=null)
            StopCoroutine(_coroutineClose);
        
        StartCoroutine(CloseScreen());
    }

    private IEnumerator OpenScreen()
    {
        yield return _waitForSeconds;
        SetActive(1,true);
        _animator.Play("LevelCubeInfoScreenUp");
    }

    private IEnumerator CloseScreen()
    {
        _animator.Play("LevelCubeInfoScreenDown");
        yield return _waitForSeconds;
        SetActive(0, false);
    }
    
    private void SetActive(int alpha,bool flag)
    {
        _cubePositionInfo.SetActive(flag);
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = flag;
        _canvasGroup.blocksRaycasts = flag;
    }
}

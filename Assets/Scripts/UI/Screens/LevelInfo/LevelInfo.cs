using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private GameObject _cubePositionInfo;
    [SerializeField] private GameObject[] _cubePositionsInfo;
    [SerializeField] private GameObject _panelCompleted;
    [SerializeField] private GameObject _lockedPanel;
    [SerializeField] private GameObject _unLockedPanel;
    [SerializeField] private int _index;
    [SerializeField] private Load _load;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
    private Coroutine _coroutineOpen;
    private Coroutine _coroutineClose;

    private bool information;

    private void Start()
    {
        information = _load.Get("LevelStatus" + _index, 0) > 0;
        _panelCompleted.SetActive((LevelState) _load.Get("LevelStatus" + _index, 0) == LevelState.Completed);
        SetActive(0, false);
        _cubePositionInfo = _cubePositionsInfo[information ? 0 : 1];
        _unLockedPanel.SetActive(information ? true : false);
        _lockedPanel.SetActive(!information);
    }

    public void Open()
    {
        if (_coroutineOpen != null)
            StopCoroutine(_coroutineOpen);

        StartCoroutine(OpenScreen());
    }

    public void Close()
    {
        if (_coroutineClose != null)
            StopCoroutine(_coroutineClose);

        StartCoroutine(CloseScreen());
    }

    private IEnumerator OpenScreen()
    {
        yield return _waitForSeconds;
        SetActive(1, true);
        _animator.Play("LevelCubeInfoScreenUp");
    }

    private IEnumerator CloseScreen()
    {
        _animator.Play("LevelCubeInfoScreenDown");
        yield return _waitForSeconds;
        SetActive(0, false);
    }

    private void SetActive(int alpha, bool flag)
    {
        _cubePositionInfo.SetActive(flag);
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = flag;
        _canvasGroup.blocksRaycasts = flag;
    }

    /*
    public void SelectComplitedInfo()
    {
        _panelComplited.SetActive(true);
    }*/
}
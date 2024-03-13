using System;
using System.Collections;
using System.Collections.Generic;
using CameraFiles;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SelectLevelButton : AbstractButton
{
    [SerializeField] private int _sceneNumber;
    [SerializeField] private Transform _target;
    [SerializeField] private CameraMover _cameraMover;
    [SerializeField] private CanvasAnimator _canvasAnimator;
    [SerializeField] private BackToMenuButton _backToMenuButton;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private bool _isMove;
    
    protected override void OnClick()
    {
        StartCoroutine(SelectLevel());
    }

    private void Update()
    {
        if (_isMove)
        {
            // _cameraMover.transform.LookAt(_target);
            _cameraMover.transform.position = Vector3.MoveTowards(_cameraMover.transform.position,
                _target.transform.position, 10 * Time.deltaTime);
        }
    }

    private IEnumerator SelectLevel()
    {
        _cameraMover.enabled = false;
        _isMove = true;
        _canvasAnimator.Close();
        _backToMenuButton.FadeBackGround();
        yield return _waitForSeconds;
        SceneManager.LoadScene(_sceneNumber);
    }
}
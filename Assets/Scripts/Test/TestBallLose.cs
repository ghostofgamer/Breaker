using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using UnityEngine;

public class TestBallLose : MonoBehaviour
{
    [SerializeField] BallTrigger _ball;

    private void OnEnable()
    {
        _ball.Dying += Show;
    }

    private void OnDisable()
    {
        _ball.Dying -= Show;
    }

    private void Show()
    {
        Debug.Log("событие");
    }
}
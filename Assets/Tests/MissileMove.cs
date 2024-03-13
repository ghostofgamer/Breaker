using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using Unity.VisualScripting;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    [SerializeField] private BallMover _ballMover;

    private void Update()
    {
        transform.position = _ballMover.transform.position;
    }
}
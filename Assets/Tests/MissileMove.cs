using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MissileMove : MonoBehaviour
{
    [SerializeField] private BallPortalMover _ballPortalMover;

    private void Update()
    {
        transform.position = _ballPortalMover.transform.position;
    }
}
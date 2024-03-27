using System;
using System.Collections;
using System.Collections.Generic;
using Bricks;
using BulletFiles;
using GameScene.BallContent;
using UnityEngine;

public class KinematicChangerLevel5a : MonoBehaviour
{
    [SerializeField] private GameObject[] _bricks;
    [SerializeField] private Brick _brick;

    /*
    private void OnEnable()
    {
        _brick.Dead += ChangeKinematic;
    }

    private void OnDisable()
    {
        _brick.Dead -= ChangeKinematic;
    }

    private void Start()
    {
        foreach (var brick in _bricks)
            brick.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void ChangeKinematic()
    {
        foreach (var brick in _bricks)
        {
            if (brick.activeSelf && brick.GetComponent<Rigidbody>().isKinematic)
                brick.GetComponent<Rigidbody>().isKinematic = false;
        }
    }*/
}
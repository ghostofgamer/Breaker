using System;
using System.Collections;
using System.Collections.Generic;
using BulletFiles;
using GameScene.BallContent;
using UnityEngine;

public class KinematicChangerLevel5a : MonoBehaviour
{
    [SerializeField] private GameObject[] _bricks;

    private void Start()
    {
        foreach (var brick in _bricks)
        {
            brick.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Ball ball)||other.collider.TryGetComponent(out Bullet bullet))
        {
            ChangeKinematic();
        }
    }

    public void ChangeKinematic()
    {
        foreach (var brick in _bricks)
        {
            if (brick.activeSelf && brick.GetComponent<Rigidbody>().isKinematic)
                brick.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out TestBall testBall))
        {
            gameObject.SetActive(false);
        }
    }
}

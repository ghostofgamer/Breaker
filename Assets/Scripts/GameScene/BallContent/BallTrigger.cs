using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallTrigger : MonoBehaviour
{
    public event UnityAction Dying;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.TryGetComponent(out Bourder bourder))
        {
            Dying?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
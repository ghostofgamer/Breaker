using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TestPlatformaMover testPlatformaMover))
        {
            _effect.SetActive(true);
            _effect.transform.parent = null;
            // Instantiate(_effect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _effect;

    /*public void Destroy()
    {
        _effect.SetActive(true);
        _effect.transform.parent = null;
        gameObject.SetActive(false);
    }*/
    
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out TestPlatformaMover testPlatformaMover))
        {
            _effect.SetActive(true);
            _effect.transform.parent = null;
            gameObject.SetActive(false);
        }
    }*/
}
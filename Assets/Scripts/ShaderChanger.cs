using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderChanger : MonoBehaviour
{
    [SerializeField] private Material _material;

    private float _duration = 3;
    private float _elapsedTime;
    
    private void Start()
    {
        StartCoroutine(Changevalue());
    }

    private IEnumerator Changevalue()
    {
        _material.SetFloat("_RimPower",5);
        float RimPower = _material.GetFloat("_RimPower");

        while (_elapsedTime < _duration)
        {
            _elapsedTime += Time.deltaTime;
            float newValue = Mathf.Lerp(RimPower, 0, _elapsedTime / _duration);
            _material.SetFloat("_RimPower",newValue);
            yield return null;
        }
        
        _material.SetFloat("_RimPower",0);
    }
}

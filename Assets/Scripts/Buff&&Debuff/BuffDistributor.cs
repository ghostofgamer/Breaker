using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDistributor : MonoBehaviour
{
    [SerializeField] private Effect[] _effects;

    private float _randomProcent = 0.3f;
    private bool _isEffect = false;
    
    public Effect AssignEffect()
    {
        _isEffect = Random.value < _randomProcent;

        if (_isEffect)
        {
            return _effects[Random.Range(0, _effects.Length)];
        }

        return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public abstract class Effect : MonoBehaviour 
{
    [SerializeField] private float _duration;
    [SerializeField] private GameObject _effect;
    [SerializeField] private BuffType _buffType;

    public BuffType BuffType => _buffType;
    
    public void Destroy()
    {
        _effect.SetActive(true);
        _effect.transform.parent = null;
        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour 
{
    [SerializeField] private float _duration;
    [SerializeField] protected GameObject _target;
}

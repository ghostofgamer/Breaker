using System.Collections;
using System.Collections.Generic;
using Levels;
using UnityEngine;

public class ColliderController : MonoBehaviour
{
    [SerializeField] private Level[] _levels;

    public void SetValue(bool enabledValue)
    {
        foreach (var level in _levels)
            level.GetComponent<BoxCollider>().enabled = enabledValue;
    }
    
    /*public void SetValueEnabled(bool enabledValue)
    {
        foreach (var level in _levels)
            level.enabled = enabledValue;
    }*/
}

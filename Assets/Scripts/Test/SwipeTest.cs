using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeTest : MonoBehaviour
{
    [SerializeField] private GameObject _scrollBar;
    private float _scrollPos = 0;
    private float[] _pos;

    private void Update()
    {
        _pos = new float[transform.childCount];
        float distance = 1f / (_pos.Length - 1);

        for (int i = 0; i < _pos.Length; i++)
        {
            _pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            _scrollPos =_scrollBar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < _pos.Length; i++)
            {
                if (_scrollPos < _pos[i] + (distance / 2) && _scrollPos > _pos[i] - (distance / 2))
                {
                    _scrollBar.GetComponent<Scrollbar>().value = Mathf.Lerp(_scrollBar.GetComponent<Scrollbar>().value, _pos[i], 0.1f);
                }    
            }
        }
    }
}
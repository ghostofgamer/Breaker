using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinLoader : MonoBehaviour
{
    [SerializeField] private Ball _ball; 
    [SerializeField] private Material[] _skinsBall;
    [SerializeField] private Load _load;
    
    private MeshRenderer _meshRenderer;
    private int _skinBallIndex;
    private int _startIndex = 0;
    
    private void Start()
    {
        _meshRenderer = _ball.GetComponent<MeshRenderer>();
        _skinBallIndex = _load.Get(Save.SkinBall, _startIndex);
        LoadSkin();
    }

    public void LoadSkin()
    {
        _meshRenderer.material = _skinsBall[_skinBallIndex];
    }
}

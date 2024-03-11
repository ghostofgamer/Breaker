using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinPlatformLoader : MonoBehaviour
{
    [SerializeField] private Platforma[] _platforms;
    [SerializeField] private Material[] _materials;
    [SerializeField] private Load _load;
    [SerializeField] private GameObject[] _skins;

    private int _startIndex = 0;

    private void Start()
    {
        int index = _load.Get(Save.ActiveCapsuleIndex, _startIndex);

        /*for (int i = 0; i < _platforms.Length; i++)
        {
            _platforms[i].GetComponent<MeshRenderer>().material = _materials[index];
        }*/
        _skins[index ].SetActive(true);
        
    }
}
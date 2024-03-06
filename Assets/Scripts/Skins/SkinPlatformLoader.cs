using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkinPlatformLoader : MonoBehaviour
{
    [SerializeField] private Platforma _platforma;
    [SerializeField] private Material[] _materials;
    [SerializeField] private Load _load;

    private int _startIndex = 0;

    private void Start()
    {
        int index = _load.Get(Save.ActiveCapsuleIndex, _startIndex);
        _platforma.GetComponent<MeshRenderer>().material = _materials[index];
    }
}

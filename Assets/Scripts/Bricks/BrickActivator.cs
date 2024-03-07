using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickActivator : MonoBehaviour
{
    [SerializeField] private GameObject _fadeObject;
    [SerializeField]private MeshRenderer _meshRenderer;

    public void Activate()
    {
        _fadeObject.SetActive(false);
        _meshRenderer.enabled = true;
    }
}

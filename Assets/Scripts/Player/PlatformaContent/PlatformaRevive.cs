using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaRevive : MonoBehaviour
{
    [SerializeField] private GameObject _mousePosition;

    private PlatformaMover _platformaMover;

    private void Start()
    {
        _platformaMover = GetComponent<PlatformaMover>();
    }

    public void Revive()
    {
        _platformaMover.Revive();
        _mousePosition.SetActive(true);
    }
}

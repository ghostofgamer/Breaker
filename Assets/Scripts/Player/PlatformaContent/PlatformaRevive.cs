using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaRevive : MonoBehaviour
{
    [SerializeField] private GameObject _mousePosition;
    
    public void Revive()
    {
        gameObject.SetActive(true);
        _mousePosition.SetActive(true);
    }
}

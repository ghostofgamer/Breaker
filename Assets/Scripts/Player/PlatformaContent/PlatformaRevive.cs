using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaRevive : MonoBehaviour
{
    [SerializeField] private GameObject _mousePosition;
    
    public void Revive()
    {
        Debug.Log("платформа оживай");
        gameObject.SetActive(true);
        _mousePosition.SetActive(true);
    }
}

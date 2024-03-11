using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Transform[] _shootPosition;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;
    [SerializeField] private Load _load;

    private int _shootPositionsAmount;
    private int _startShootPositions = 2;

    private void Start()
    {
        _shootPositionsAmount = _load.Get(Save.Laser,_startShootPositions);
        // Debug.Log(_shootPositionsAmount);
    }

    public void Shoot()
    {
        int index = Random.Range(0, _shootPositionsAmount);
        Instantiate(_bullet, _shootPosition[index].position, Quaternion.identity, _container);
    }
    
}
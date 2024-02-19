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

    public void Shoot()
    {
        int index = UnityEngine.Random.Range(0, _shootPosition.Length);
        Instantiate(_bullet, _shootPosition[index].position, Quaternion.identity, _container);
    }
}
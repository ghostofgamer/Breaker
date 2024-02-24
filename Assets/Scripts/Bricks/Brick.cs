using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public abstract class Brick : MonoBehaviour
{
    [SerializeField] protected BrickCounter BrickCounter;
    [SerializeField] protected GameObject BonusPrefab;
    [SerializeField] protected bool IsBonus;
    [SerializeField] protected int Reward;
    [SerializeField] protected int BonusAmount;

    private int _minBonus = 1;
    private int _maxBonus = 3;
    private float _bonusRadius = 1.65f;
    
    private void Start()
    {
        IsBonus = Random.value > 0.5f;
        BonusAmount = Random.Range(_minBonus, _maxBonus);
    }

    public abstract void Die();

    public void Init(BrickCounter brickCounter)
    {
        BrickCounter = brickCounter;
    }

    public void GetBonus()
    {
        if (!IsBonus)
            return;
        
        for (int i = 0; i < BonusAmount; i++)
        {
            float angle = i * Mathf.PI * 2 / BonusAmount;
            float x = transform.position.x + Mathf.Cos(angle) * _bonusRadius;
            float z = transform.position.z + Mathf.Sin(angle) * _bonusRadius;
            Vector3 bonusPosition = new Vector3(x, transform.position.y, z);
            Instantiate(BonusPrefab, bonusPosition, Quaternion.identity);
        }
    }
}

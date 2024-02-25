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
    [SerializeField] protected BuffDistributor BuffDistributor;
    [SerializeField] protected bool IsImmortal = false;

    [SerializeField] protected Effect Effect;

    private int _minBonus = 1;
    private int _maxBonus = 3;
    private float _bonusRadius = 1.65f;
    private float _randomProcent = 0.5f;
    
    public Effect EffectElement => Effect;
    public bool IsImmortalFlag => IsImmortal;

    private void Start()
    {
        if (!IsImmortal)
        {
            IsBonus = Random.value > _randomProcent;
            Effect = BuffDistributor.AssignEffect();
            BonusAmount = Random.Range(_minBonus, _maxBonus);
        }
    }

    public abstract void Die();

    public void Init(BrickCounter brickCounter, BuffDistributor buffDistributor)
    {
        BrickCounter = brickCounter;
        BuffDistributor = buffDistributor;
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

    public void SetBoolImmortal(bool immortal)
    {
        IsImmortal = immortal;
    }

    protected void GetBuff()
    {
        if (Effect == null)
            return;
        
        Instantiate(Effect, transform.position, Quaternion.identity);
    }
}
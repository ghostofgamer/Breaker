using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : Brick
{
    [SerializeField] private GameObject particleEffectPrefab;
    [SerializeField] private Effect _effect;
    [SerializeField] private GameObject _bonusPrefab;
    [SerializeField] private bool _isBonus;

    private float _bonusRadius = 1.65f;
    private bool _isImmortal = false;
    
    public bool IsBonus => _isBonus;
    public Effect Effect => _effect;
    
    private void OnCollisionEnter(Collision other)
    {
    }

    public override void Die()
    {
        Destroy();
    }

    private void Destroy()
    {
        if (_isImmortal)
            return;
        
        particleEffectPrefab.SetActive(true);
        particleEffectPrefab.transform.parent = null;

        if (_effect != null)
            Instantiate(_effect, transform.position, Quaternion.identity);

        BrickCounter.ChangeValue(GetComponent<Brick>().Reward);
        GetBonus();
        gameObject.SetActive(false);
    }

    public void SetEffect(Effect effect)
    {
        _effect = effect;
    }
    
    public void SetBoolValue(bool isBonus)
    {
        _isBonus = isBonus;
    }

    public void SetBoolImmortal(bool immortal)
    {
        _isImmortal = immortal;
    }
    
    private void GetBonus()
    {
        if (!_isBonus)
            return;

        int amount = UnityEngine.Random.Range(1, 5);
        
        for (int i = 0; i < amount; i++)
        {
            float angle = i * Mathf.PI * 2 / amount;
            float x = transform.position.x + Mathf.Cos(angle) * _bonusRadius;
            float z = transform.position.z + Mathf.Sin(angle) * _bonusRadius;
            Vector3 bonusPosition = new Vector3(x, transform.position.y, z);
            
            Instantiate(_bonusPrefab, bonusPosition, Quaternion.identity);
        }
    }
}
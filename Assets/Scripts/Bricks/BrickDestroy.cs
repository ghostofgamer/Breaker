using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : Brick
{
    [SerializeField] private GameObject particleEffectPrefab;
    [SerializeField] private Effect _effect;

    private bool _isImmortal = false;

    public Effect Effect => _effect;

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

        BrickCounter.ChangeValue(Reward);
        GetBonus();
        gameObject.SetActive(false);
    }

    public void SetEffect(Effect effect)
    {
        _effect = effect;
    }
    
    public void SetBoolValue(bool isBonus)
    {
        IsBonus = isBonus;
    }

    public void SetBoolImmortal(bool immortal)
    {
        _isImmortal = immortal;
    }
}
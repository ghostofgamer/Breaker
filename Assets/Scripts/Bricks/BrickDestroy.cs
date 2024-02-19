using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : MonoBehaviour
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

    public void Destroy()
    {
        if (_isImmortal)
            return;
        
        particleEffectPrefab.SetActive(true);
        particleEffectPrefab.transform.parent = null;
        /*_effect.transform.parent = null;
        _effect.gameObject.SetActive(true);*/
        if (_effect != null)
            Instantiate(_effect, transform.position, Quaternion.identity);

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

        int amount = Random.Range(1, 5);
        
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
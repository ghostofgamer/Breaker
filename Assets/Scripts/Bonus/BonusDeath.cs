using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class BonusDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectDie;
    [SerializeField] private GameObject _bonusFly;
    [SerializeField] private TMP_Text _bonusCountTxt;
    
    public int Reward { get; private set; }

    // public int Reward => _reward;

    private void Start()
    {
        Reward = Random.Range(1, 3);
        _bonusCountTxt.text = Reward.ToString();
    }

    public void Die()
    {
        _effectDie.transform.parent = null;
        _effectDie.Play();
        BonusFlying();
        gameObject.SetActive(false);
    }

    private void BonusFlying()
    {
        _bonusFly.transform.parent = null;
        _bonusFly.transform.position = transform.position;
        _bonusFly.SetActive(true);
    }
}
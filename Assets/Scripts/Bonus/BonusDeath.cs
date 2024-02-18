using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDeath : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effectDie;

    public void Die()
    {
        _effectDie.transform.parent = null;
        _effectDie.Play();
        gameObject.SetActive(false);
    }
}

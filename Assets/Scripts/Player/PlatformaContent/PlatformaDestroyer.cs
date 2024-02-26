using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformaDestroyer : MonoBehaviour
{
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private ParticleSystem _victoryEffect;
    [SerializeField] private ParticleSystem _loseEffect;
    [SerializeField] private GameObject _mousePosition;

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += OnVictoriousDestruction;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= OnVictoriousDestruction;
    }

    private void OnVictoriousDestruction()
    {
        _victoryEffect.transform.parent = null;
        _victoryEffect.Play();
        gameObject.SetActive(false);
        _mousePosition.SetActive(false);
    }
    
    private void OnLosingDestruction()
    {
        
    }
}

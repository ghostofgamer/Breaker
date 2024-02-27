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
    [SerializeField] private BallTrigger _ballTrigger;

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += OnVictoriousDestruction;
        _ballTrigger.Dying += OnLosingDestruction;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= OnVictoriousDestruction;
        _ballTrigger.Dying -= OnLosingDestruction;
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
        _loseEffect.transform.parent = null;
        _loseEffect.Play();
        gameObject.SetActive(false);
        _mousePosition.SetActive(false);
    }
}

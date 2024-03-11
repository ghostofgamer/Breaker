using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Transform _bricksContainer;
    [SerializeField] private Brick[] _bricks;
    [SerializeField]private ParticleSystem _startEffect;
    // [SerializeField] private ParticleSystem _victoryEffect;
    [SerializeField] private Platforma _platforma;
    [SerializeField] private Ball _ball;

    private void Start()
    {
        StartCoroutine(SetActive());
    }

    private IEnumerator SetActive()
    {
        foreach (var brick in _bricks)
        {
            brick.GetComponent<BrickActivator>().Activate();
            yield return new WaitForSeconds(0.05f);
        }
        
        yield return new WaitForSeconds(0.05f);
        _startEffect.Play();
        yield return new WaitForSeconds(1f);
        _platforma.gameObject.SetActive(true);
        _ball.gameObject.SetActive(true);
    }

    public void RevivePlatform()
    {
        StartCoroutine(ComeLife());
    }
    
    private IEnumerator ComeLife()
    {
        _startEffect.Play();
        yield return new WaitForSeconds(1f);
        _platforma.GetComponent<PlatformaRevive>().Revive();
        _ball.GetComponent<BallRevive>().Revive();
    }
}
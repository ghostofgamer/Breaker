using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField]private GameObject _portal;
    [SerializeField] protected BuffType _buffType;
    [SerializeField] private GameObject[] _walls;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(3f);
    
    public void PortalActivated(BallPortalMover ballPortalMover)
    {
        if (ballPortalMover.GetComponent<Ball>().TryApplyEffect(_buffType))
            StartCoroutine(OnPortalActivated(ballPortalMover));
    }

    private IEnumerator OnPortalActivated(BallPortalMover ballPortalMover)
    {
        // _particleSystem.Play();
        foreach (var wall in _walls)
        {
            // wall.gameObject.SetActive(false);
            wall.GetComponent<BoxCollider>().enabled = false;
        }
        
        ballPortalMover.SetValue(true);
        _portal.SetActive(true);
        yield return _waitForSeconds;
        _portal.SetActive(false);
        
        foreach (var wall in _walls)
        {
            wall.GetComponent<BoxCollider>().enabled = true;
            // wall.gameObject.SetActive(true);
        }
        
        yield return new WaitForSeconds(0.1f);
        ballPortalMover.SetValue(false);
        // _particleSystem.Stop();
        ballPortalMover.GetComponent<Ball>().DeleteEffect(_buffType);
    }
}

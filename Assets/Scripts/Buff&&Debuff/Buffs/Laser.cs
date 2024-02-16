using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _duration;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
    private Coroutine _coroutine;
    private float _elapsedTime = 0;

    public void Shooting(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            _coroutine =  StartCoroutine(OnShoot(platformaMover));
    }
    
    private IEnumerator OnShoot(PlatformaMover platformaMover)
    {
        _elapsedTime = 0;
        
        while (_elapsedTime < _duration)
        {
            _weapon.Shoot();
            yield return _waitForSeconds;
            _elapsedTime += Time.deltaTime;
        }
        
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
        Stop();
    }

    private void Stop()
    {
        StopCoroutine(_coroutine);
    }
}
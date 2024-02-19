using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Modification
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _duration;
    // [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
    private Coroutine _coroutine;
    private float _elapsedTime = 0;

    public override void ApplyModification(Player player)
    {
        if (player.TryApplyEffect(this))
            _coroutine =  StartCoroutine(OnShoot());
    }

    public override void StopModification(Player player)
    {
        Stop();
    }

    /*public void Shooting(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            _coroutine =  StartCoroutine(OnShoot(platformaMover));
    }*/

    private IEnumerator OnShoot()
    {
        _elapsedTime = 0;
        
        while (_elapsedTime < _duration)
        {
            _weapon.Shoot();
            yield return _waitForSeconds;
            _elapsedTime += Time.deltaTime;
        }
        
        Stop();
    }

    private void Stop()
    {
        Player.DeleteEffect(this);
        StopCoroutine(_coroutine);
    }
}
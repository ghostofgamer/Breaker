using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Laser : Modification
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private float _timeBetweenShots;
    
    private float _elapsedTime = 0;

    protected override void Start()
    {
        WaitForSeconds = new WaitForSeconds(_timeBetweenShots);
    }

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            Coroutine = StartCoroutine(OnShoot());
        }
    }

    public override void StopModification()
    {
        Stop();
    }

    private IEnumerator OnShoot()
    {
        _elapsedTime = 0;

        while (_elapsedTime < Duration)
        {
            _weapon.Shoot();
            yield return WaitForSeconds;
            _elapsedTime += Time.deltaTime;
        }

        Stop();
        Player.DeleteEffect(this);
    }

    private void Stop()
    {
        StopCoroutine(Coroutine);
    }
}
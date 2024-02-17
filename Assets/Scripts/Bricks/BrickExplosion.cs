using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BrickExplosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private ParticleSystem _explodeEffect;
    [SerializeField] private ParticleSystem _bombFuseEffect;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.6f);
    
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
        }
    }*/

    public void Explode()
    {
        StartCoroutine(OnExplode());
    }

    private IEnumerator OnExplode()
    {
        _bombFuseEffect.Play();
        yield return _waitForSeconds;
        Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, _radius);

        for (int i = 0; i < overlappingColliders.Length; i++)
        {
            if(overlappingColliders[i].TryGetComponent(out BrickDestroy brick))
            {
                brick.GetComponent<Rigidbody>().AddExplosionForce(_force,transform.position,_radius);
            }
        }

        _explodeEffect.transform.parent = null;
        _explodeEffect.Play();
        Destroy(gameObject);
    }
}

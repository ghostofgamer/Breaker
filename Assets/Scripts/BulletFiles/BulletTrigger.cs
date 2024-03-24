using System;
using System.Collections;
using Bricks;
using GameScene;
using ObjectPoolFiles;
using UnityEngine;

namespace BulletFiles
{
    public class BulletTrigger : Bullet
    {
        [SerializeField] private ParticleSystem _explosionEffect;
        
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private Coroutine _coroutine;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Brick brick))
            {
                Hit();
                brick.Die();
                // gameObject.SetActive(false);
            }

            if (other.TryGetComponent(out WallTrigger wallTrigger))
            {
                Hit();
                // gameObject.SetActive(false);
            }
        }

        private void Hit()
        {
            if(_coroutine!=null)
                StopCoroutine(_coroutine);
            
            StartCoroutine(HitTarget());
        }

        private IEnumerator HitTarget()
        {
            BulletMover.enabled = false;
            _explosionEffect.Play();
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}
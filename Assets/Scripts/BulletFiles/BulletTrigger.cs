using System.Collections;
using Bricks;
using GameScene;
using UnityEngine;

namespace BulletFiles
{
    public class BulletTrigger : Bullet
    {
        [SerializeField] private ParticleSystem _explosionEffect;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out BrickCoordinator brick))
            {
                Hit();
                brick.Die();
            }

            if (other.TryGetComponent(out WallTrigger wallTrigger))
            {
                Hit();
            }
        }

        private void Hit()
        {
            StartCoroutine(HitTarget());
        }

        private IEnumerator HitTarget()
        {
            StopBullet();
            _explosionEffect.Play();
            yield return _waitForSeconds;
            gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using UnityEngine;

namespace Bricks
{
    public class BrickExplosion : Brick
    {
        [SerializeField] private float _radius;
        [SerializeField] private float _force;
        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private ParticleSystem _bombFuseEffect;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.6f);
        private bool _wickBurning = false;

        public float Radius => _radius;
        
        public override void Die()
        {
            if (IsImmortal)
                return;

            if (!_wickBurning && IsTargetBonus)
            {
                Destroy();
            }

            if (!_wickBurning)
            {
                StartCoroutine(OnExplode());
            }
        }

        private IEnumerator OnExplode()
        {
            // Debug.Log("радиус " + _radius);
            _wickBurning = true;
            // _bombFuseEffect.Play();
            _bombFuseEffect.gameObject.SetActive(true);
            yield return _waitForSeconds;
            // _audioSource.PlayOneShot(_audioSource.clip);
            Detonate();


            /*GetBonus();
            GetBuff();
            BrickCounter.ChangeValue(Reward);
            Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, _radius);

            for (int i = 0; i < overlappingColliders.Length; i++)
            {
                if (overlappingColliders[i].TryGetComponent(out BrickDestroy brick))
                {
                    brick.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
                }

                // if (overlappingColliders[i].TryGetComponent(out BrickExplosion brickExplosion))
                // {
                //     brickExplosion.Die();
                // }
            }

            _explodeEffect.transform.parent = null;
            // _explodeEffect.Play();
            _explodeEffect.gameObject.SetActive(true);
            gameObject.SetActive(false);*/
        }

        public void Detonate()
        {
            GetBonus();
            GetBuff();
            BrickCounter.ChangeValue(Reward);
            Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, _radius);

            for (int i = 0; i < overlappingColliders.Length; i++)
            {
                if (overlappingColliders[i].TryGetComponent(out BrickDestroy brick))
                {
                    brick.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
                }

                // if (overlappingColliders[i].TryGetComponent(out BrickExplosion brickExplosion))
                // {
                //     brickExplosion.Die();
                // }
            }

            _explodeEffect.transform.parent = null;
            // _explodeEffect.Play();
            _explodeEffect.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }
    }
}
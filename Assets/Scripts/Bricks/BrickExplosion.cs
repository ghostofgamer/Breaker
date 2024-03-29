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

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.6f);
        private bool _wickBurning = false;

        public float Radius => _radius;

        public override void Die()
        {
            if (IsImmortal)
            {
                AudioSource.PlayOneShot(AudioSource.clip);
                return;
            }

            if (!_wickBurning && IsTargetBonus)
            {
                Destroy();
            }

            if (!_wickBurning)
            {
                StartCoroutine(EnableExplode());
            }
        }

        public void Detonate()
        {
            BrickDie();
            LootDropper.DropBonus();
            LootDropper.DropBuff(EffectElement);
            BrickCounter.ChangeValue(Reward);
            Collider[] overlappingColliders = Physics.OverlapSphere(transform.position, _radius);

            for (int i = 0; i < overlappingColliders.Length; i++)
            {
                if (overlappingColliders[i].TryGetComponent(out BrickDestroy brick))
                {
                    brick.GetComponent<Rigidbody>().AddExplosionForce(_force, transform.position, _radius);
                }
            }

            _explodeEffect.transform.parent = null;
            _explodeEffect.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }

        public void SetRadius(float radius)
        {
            _radius = radius;
        }

        private IEnumerator EnableExplode()
        {
            _wickBurning = true;
            _bombFuseEffect.gameObject.SetActive(true);
            yield return _waitForSeconds;
            Detonate();
        }
    }
}
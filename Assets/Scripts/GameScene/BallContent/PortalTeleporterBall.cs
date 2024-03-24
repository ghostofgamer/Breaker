using System;
using ObjectPoolFiles;
using UnityEngine;

namespace GameScene.BallContent
{
    public class PortalTeleporterBall : MonoBehaviour
    {
        protected readonly int MaxAmmo = 50;
        
        // [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private EffectActivator _effectActivator;
        [SerializeField] private ParticleSystem _missileEffect;
        [SerializeField] private float _xMinPosition;
        [SerializeField] private float _xMaxPosition;
        [SerializeField] private float _zMaxPosition;
        [SerializeField] private float _zMinPosition;
        // [SerializeField] private WallTrigger[] _wallTrigger;
        [SerializeField] private Transform _container;
        
        private ObjectPool<EffectActivator> _pool;
        private bool _autoExpand = true;

        private void Start()
        {
            _pool = new ObjectPool<EffectActivator>(_effectActivator, MaxAmmo, _container);
            _pool.SetAutoExpand(_autoExpand);
        }

        public void Init(ParticleSystem missileEffect)
        {
            _missileEffect = missileEffect;
        }

        public void TeleportBall()
        {
            if (transform.position.x > _xMaxPosition)
            {
                Teleport(new Vector3(_xMinPosition, transform.position.y, transform.position.z));
            }

            if (transform.position.x < _xMinPosition)
            {
                Teleport(new Vector3(_xMaxPosition, transform.position.y, transform.position.z));
            }

            if (transform.position.z < _zMinPosition)
            {
                Teleport(new Vector3(transform.position.x, transform.position.y, _zMaxPosition));
            }

            if (transform.position.z > _zMaxPosition)
            {
                Teleport(new Vector3(transform.position.x, transform.position.y, _zMinPosition));
            }
        }

        private void Teleport(Vector3 position)
        {
            // Instantiate(_particleSystem, transform.position, Quaternion.identity);
            ActivationEffect();
            _missileEffect.gameObject.SetActive(false);
            transform.position = position;
            _missileEffect.gameObject.SetActive(true);
            ActivationEffect();
            // Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }

        private void ActivationEffect()
        {
            if (_pool.TryGetObject(out EffectActivator portalEffect, _effectActivator))
            {
                portalEffect.Init(transform.position);
                portalEffect.gameObject.SetActive(true);
                portalEffect.Play();
            }
        }
    }
}
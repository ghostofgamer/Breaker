using System;
using ModificationFiles;
using Statistics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bricks
{
    public abstract class Brick : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private bool _isBonus;
        [SerializeField] private int _reward;
        [SerializeField] private int _bonusAmount;
        [SerializeField] private BuffDistributor _buffDistributor;
        [SerializeField] private bool _isImmortal = false;
        [SerializeField] private Effect _effect;
        [SerializeField] private GameObject _hologramEffectDie;
        [SerializeField] private GameObject _targetVisual;
        [SerializeField] private bool _isEternal = false;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private LootDropper _lootDropper;

        private int _minBonus = 1;
        private int _maxBonus = 3;
        private float _randomProcent = 0.5f;
        protected bool IsTargetBonus;

        public event Action Dead;

        public bool IsBonus => _isBonus;

        public Effect EffectElement => _effect;

        public bool IsEternal => _isEternal;

        public int BonusAmount => _bonusAmount;
        protected LootDropper LootDropper => _lootDropper;

        protected AudioSource AudioSource => _audioSource;

        protected int Reward => _reward;

        protected BrickCounter BrickCounter => _brickCounter;

        protected bool IsImmortal => _isImmortal;

        private void Start()
        {
            if (!_isEternal)
            {
                _isBonus = Random.value > _randomProcent;
                _effect = _buffDistributor.AssignEffect();
                _bonusAmount = Random.Range(_minBonus, _maxBonus);
                _brickCounter.AddBricks();
            }
        }

        public abstract void Die();

        public void Init(BrickCounter brickCounter, BuffDistributor buffDistributor)
        {
            _brickCounter = brickCounter;
            _buffDistributor = buffDistributor;
        }

        public void SetBoolImmortal(bool immortal)
        {
            _isImmortal = immortal;
        }

        public void SetEffect(Effect effect, bool activation)
        {
            _effect = effect;
            _targetVisual.SetActive(activation);
            IsTargetBonus = activation;
        }

        /*protected void DropBonus()
        {
            if (!_isBonus)
                return;

            _fragmentsCounter.SetAmountFragments(_bonusAmount);

            for (int i = 0; i < _bonusAmount; i++)
            {
                float angle = (i * Mathf.PI * _factor) / _bonusAmount;
                float x = transform.position.x + (Mathf.Cos(angle) * _bonusRadius);
                float z = transform.position.z + (Mathf.Sin(angle) * _bonusRadius);
                Vector3 bonusPosition = new Vector3(x, transform.position.y, z);
                Instantiate(_bonusPrefab, bonusPosition, Quaternion.identity);
            }
        }
        */

        protected void Destroy()
        {
            if (_isImmortal)
            {
                _audioSource.PlayOneShot(_audioSource.clip);
                return;
            }

            BrickDie();
            _hologramEffectDie.SetActive(true);
            _hologramEffectDie.transform.parent = null;
            _lootDropper.DropBuff(_effect);
            _brickCounter.ChangeValue(_reward);
            _lootDropper.DropBonus();
            gameObject.SetActive(false);
        }

        protected void BrickDie()
        {
            Dead?.Invoke();
        }
    }
}
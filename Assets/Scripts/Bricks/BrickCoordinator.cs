using System;
using ModificationFiles;
using Statistics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bricks
{
    public abstract class BrickCoordinator : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private bool _isBonus;
        [SerializeField] private BuffDistributor _buffDistributor;
        [SerializeField] private bool _isImmortal = false;
        [SerializeField] private GameObject _targetVisual;
        [SerializeField] private bool _isEternal = false;

        private AudioSource _audioSource;
        private LootDropper _lootDropper;
        private int _reward = 5;
        private int _bonusAmount;
        private Effect _effect;
        private bool _isTargetBonus;
        private int _minBonus = 1;
        private int _maxBonus = 3;
        private float _randomProcent = 0.5f;

        public event Action Dead;

        public bool IsBonus => _isBonus;

        public Effect EffectElement => _effect;

        public bool IsEternal => _isEternal;

        public int BonusAmount => _bonusAmount;

        public bool IsImmortal => _isImmortal;

        public AudioSource AudioSource => _audioSource;

        public LootDropper LootDropper => _lootDropper;

        public int Reward => _reward;

        public BrickCounter BrickCounter => _brickCounter;

        protected bool IsTargetBonus => _isTargetBonus;

        protected virtual void Start()
        {
            _lootDropper = GetComponent<LootDropper>();
            _audioSource = GetComponent<AudioSource>();
                    
            if (!_isEternal)
            {
                _isBonus = Random.value > _randomProcent;
                _effect = _buffDistributor.GetAssignEffect();
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

        public void EnableImmortalEffect()
        {
            _isImmortal = true;
        }

        public void DisableImmortalEffect()
        {
            _isImmortal = false;
        }

        public void SetEffect(Effect effect)
        {
            _effect = effect;
        }

        public void EnableTargetBonus()
        {
            _targetVisual.SetActive(true);
            _isTargetBonus = true;
        }

        public void DisableTargetBonus()
        {
            _targetVisual.SetActive(false);
            _isTargetBonus = false;
        }

        public void BrickDie()
        {
            Dead?.Invoke();
        }
    }
}
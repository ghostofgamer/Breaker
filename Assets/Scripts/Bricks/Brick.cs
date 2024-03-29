using ModificationFiles;
using Statistics;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace Bricks
{
    public abstract class Brick : MonoBehaviour
    {
        [SerializeField] protected BrickCounter BrickCounter;
        [SerializeField] protected GameObject BonusPrefab;
        [SerializeField] protected bool IsBonus;
        [SerializeField] protected int Reward;
        [SerializeField] protected int BonusAmount;
        [SerializeField] protected BuffDistributor BuffDistributor;
        [SerializeField] protected bool IsImmortal = false;
        [SerializeField] protected Effect Effect;
        [SerializeField] private GameObject _hologramEffectDie;
        [SerializeField] private GameObject _targetVisual;
        [SerializeField] private FragmentsCounter _fragmentsCounter;
        [SerializeField] private bool _isEternal = false;
        [SerializeField] protected AudioSource AudioSource;

        private int _minBonus = 1;
        private int _maxBonus = 3;
        private float _bonusRadius = 1.65f;
        private float _randomProcent = 0.5f;
        private int _factor = 2;
        protected bool IsTargetBonus;

        public event UnityAction Dead;

        public Effect EffectElement => Effect;
        
        public bool IsEternal => _isEternal;

        private void Start()
        {
            if (!_isEternal)
            {
                IsBonus = Random.value > _randomProcent;
                Effect = BuffDistributor.AssignEffect();
                BonusAmount = Random.Range(_minBonus, _maxBonus);
                BrickCounter.AddBricks(0);
            }
        }

        public abstract void Die();

        public void Init(BrickCounter brickCounter, BuffDistributor buffDistributor, FragmentsCounter fragmentsCounter)
        {
            BrickCounter = brickCounter;
            BuffDistributor = buffDistributor;
            _fragmentsCounter = fragmentsCounter;
        }

        public void GetBonus()
        {
            if (!IsBonus)
                return;

            _fragmentsCounter.SetAmountFragments(BonusAmount);

            for (int i = 0; i < BonusAmount; i++)
            {
                float angle = (i * Mathf.PI * _factor) / BonusAmount;
                float x = transform.position.x + (Mathf.Cos(angle) * _bonusRadius);
                float z = transform.position.z + (Mathf.Sin(angle) * _bonusRadius);
                Vector3 bonusPosition = new Vector3(x, transform.position.y, z);
                Instantiate(BonusPrefab, bonusPosition, Quaternion.identity);
            }
        }

        public void SetBoolImmortal(bool immortal)
        {
            IsImmortal = immortal;
        }

        public void SetEffect(Effect effect, bool activation)
        {
            Effect = effect;
            _targetVisual.SetActive(activation);
            IsTargetBonus = activation;
        }

        protected void GetBuff()
        {
            if (Effect == null)
                return;

            Instantiate(Effect, transform.position, Quaternion.identity);
        }

        protected void Destroy()
        {
            if (IsImmortal)
            {
                AudioSource.PlayOneShot(AudioSource.clip);
                return;
            }

            BrickDie();
            _hologramEffectDie.SetActive(true);
            _hologramEffectDie.transform.parent = null;
            GetBuff();
            BrickCounter.ChangeValue(Reward);
            GetBonus();
            gameObject.SetActive(false);
        }

        protected void BrickDie()
        {
            Dead?.Invoke();
        }
    }
}
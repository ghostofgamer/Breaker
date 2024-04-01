using ModificationFiles;
using Statistics;
using UnityEngine;

namespace Bricks
{
    public class LootDropper : MonoBehaviour
    {
        [SerializeField] private BrickCoordinator _brickCoordinator;
        [SerializeField] private GameObject _bonusPrefab;
        [SerializeField] private FragmentsCounter _fragmentsCounter;

        private int _factor = 2;
        private float _bonusRadius = 1.65f;

        public void Init(FragmentsCounter fragmentsCounter)
        {
            _fragmentsCounter = fragmentsCounter;
        }

        public void DropBonus()
        {
            if (!_brickCoordinator.IsBonus)
                return;

            _fragmentsCounter.SetAmountFragments(_brickCoordinator.BonusAmount);

            for (int i = 0; i < _brickCoordinator.BonusAmount; i++)
            {
                float angle = (i * Mathf.PI * _factor) / _brickCoordinator.BonusAmount;
                float x = transform.position.x + (Mathf.Cos(angle) * _bonusRadius);
                float z = transform.position.z + (Mathf.Sin(angle) * _bonusRadius);
                Vector3 bonusPosition = new Vector3(x, transform.position.y, z);
                Instantiate(_bonusPrefab, bonusPosition, Quaternion.identity);
            }
        }

        public void DropBuff(Effect effect)
        {
            if (effect == null)
                return;

            Instantiate(effect, transform.position, Quaternion.identity);
        }
    }
}
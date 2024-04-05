using System.Collections;
using Bricks;
using Statistics;
using UnityEngine;

namespace ModificationFiles.DebuffsFiles
{
    public class MoreBrick : Modification
    {
        [SerializeField] private Transform _bricksContainer;
        [SerializeField] private int _amountBricks;
        [SerializeField] private GameObject _brickPrefab;
        [SerializeField] private float _spawnRadius;
        [SerializeField] private Transform _spawnPosition;
        [SerializeField] private BrickCounter _brickCounter;
        [SerializeField] private BuffDistributor _buffDistributor;
        [SerializeField] private FragmentsCounter _fragmentsCounter;

        private float _localScale = 0.02f;

        public override void OnApplyModification()
        {
            if (Player.TryApplyEffect(this))
            {
                if (Coroutine != null)
                    StopCoroutine(Coroutine);

                StartCoroutine(OnMoreBricksActivated());
                ShowNameEffect();
            }
        }

        public override void StopModification()
        {
        }

        private IEnumerator OnMoreBricksActivated()
        {
            for (int i = 0; i < _amountBricks; i++)
            {
                Vector3 randomPoint = Random.insideUnitCircle * _spawnRadius;
                Vector3 spawnPosition = _spawnPosition.position + new Vector3(randomPoint.x, 0, randomPoint.y);
                GameObject cube = Instantiate(_brickPrefab, _bricksContainer);
                cube.GetComponent<BrickCoordinator>().Init(_brickCounter, _buffDistributor);
                cube.GetComponent<LootDropper>().Init(_fragmentsCounter);
                cube.transform.position = spawnPosition;
                cube.transform.localScale = new Vector3(_localScale, _localScale, _localScale);
                yield return WaitForSeconds;
            }

            Player.DeleteEffect(this);
        }
    }
}
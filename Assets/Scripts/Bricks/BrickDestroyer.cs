using UnityEngine;

namespace Bricks
{
    [RequireComponent(typeof(BrickCoordinator))]
    public class BrickDestroyer : MonoBehaviour
    {
        [SerializeField] private GameObject _hologramEffectDie;

        private BrickCoordinator _brickCoordinator;

        private void Start()
        {
            _brickCoordinator = GetComponent<BrickCoordinator>();
        }

        public void Destroy()
        {
            if (_brickCoordinator.IsImmortal)
            {
                _brickCoordinator.AudioSource.PlayOneShot(_brickCoordinator.AudioSource.clip);
                return;
            }

            _hologramEffectDie.SetActive(true);
            _hologramEffectDie.transform.parent = null;
            _brickCoordinator.LootDropper.DropBuff(_brickCoordinator.EffectElement);
            _brickCoordinator.BrickCounter.ChangeValue(_brickCoordinator.Reward);
            _brickCoordinator.LootDropper.DropBonus();
            gameObject.SetActive(false);
        }
    }
}

using UnityEngine;

namespace Bricks
{
    [RequireComponent(typeof(Brick))]
    public class BrickDestroyer : MonoBehaviour
    {
        [SerializeField] private GameObject _hologramEffectDie;

        private Brick _brick;

        private void Start()
        {
            _brick = GetComponent<Brick>();
        }

        public void Destroy()
        {
            if (_brick.IsImmortal)
            {
                _brick.AudioSource.PlayOneShot( _brick.AudioSource.clip);
                return;
            }
            
            _hologramEffectDie.SetActive(true);
            _hologramEffectDie.transform.parent = null;
            _brick.LootDropper.DropBuff(_brick.EffectElement);
            _brick.BrickCounter.ChangeValue(_brick.Reward);
            _brick.LootDropper.DropBonus();
            gameObject.SetActive(false);
        }
    }
}

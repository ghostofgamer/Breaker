using BulletFiles;
using ObjectPoolFiles;
using SaveAndLoad;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WeaponFiles
{
    public class Weapon : MonoBehaviour
    {
        private const string Laser = "Laser";
        private readonly int MaxAmmo = 50;

        [SerializeField] private Transform[] _shootPosition;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _container;
        [SerializeField] private Load _load;
        [SerializeField] private AudioSource _audioSource;

        private ObjectPool<Bullet> _pool;
        private int _shootPositionsAmount;
        private int _startShootPositions = 2;
        private int _index;

        private void Start()
        {
            _pool = new ObjectPool<Bullet>(_bullet, MaxAmmo, _container);
            _pool.EnableAutoExpand();
            _shootPositionsAmount = _load.Get(Laser, _startShootPositions);
        }

        public void Shoot()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _index = Random.Range(0, _shootPositionsAmount);

            if (_pool.TryGetObject(out Bullet bullet, _bullet))
            {
                bullet.Init(_shootPosition[_index].position);
                bullet.gameObject.SetActive(true);
            }
        }
    }
}
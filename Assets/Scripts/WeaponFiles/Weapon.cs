using BulletFiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace WeaponFiles
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private Transform[] _shootPosition;
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _container;
        [SerializeField] private Load _load;

        private int _shootPositionsAmount;
        private int _startShootPositions = 2;
        private int _index;
    
        private void Start()
        {
            _shootPositionsAmount = _load.Get(Save.Laser,_startShootPositions);
        }

        public void Shoot()
        {
            _index = Random.Range(0, _shootPositionsAmount);
            Instantiate(_bullet, _shootPosition[_index].position, Quaternion.identity, _container);
        }
    }
}
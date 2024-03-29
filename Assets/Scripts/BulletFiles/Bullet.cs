using UnityEngine;

namespace BulletFiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private BulletMover _bulletMover;

        public void Init(Vector3 shootPosition)
        {
            transform.position = shootPosition;
            _bulletMover.enabled = true;
        }

        protected void StopBullet()
        {
            _bulletMover.enabled = false;
        }
    }
}
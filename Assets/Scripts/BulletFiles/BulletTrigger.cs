using Bricks;
using GameScene;
using UnityEngine;

namespace BulletFiles
{
    public class BulletTrigger : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _explosion;
    
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Brick brick))
            {
                brick.Die();
                gameObject.SetActive(false);
            }
        
            if (other.TryGetComponent(out WallTrigger wallTrigger))
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                gameObject.SetActive(false);
            }
        }
    }
}

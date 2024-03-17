using GameScene.BallContent;
using UnityEngine;

namespace Bricks.Etertnal
{
    public class BrickEternal : Brick
    {
        [SerializeField] private AudioSource _audioSource;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball ball))
            {
                _audioSource.PlayOneShot(_audioSource.clip);
            }
        }

        public override void Die()
        {
        }
    }
}
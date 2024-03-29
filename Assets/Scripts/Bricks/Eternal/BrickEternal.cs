using GameScene.BallContent;
using UnityEngine;

namespace Bricks.Eternal
{
    public class BrickEternal : Brick
    {
        [SerializeField] private AudioSource _sourceAudio;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Ball ball))
                _sourceAudio.PlayOneShot(_sourceAudio.clip);
        }

        public override void Die()
        {
        }
    }
}
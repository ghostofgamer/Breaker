using UnityEngine;

namespace Bricks
{
    public class SimpleBrick : BrickCoordinator
    {
        private BrickDestroyer _brickDestroyer;

        protected override void Start()
        {
            base.Start();
            _brickDestroyer = GetComponent<BrickDestroyer>();
        }

        public override void Die()
        {
            _brickDestroyer.Destroy();
        }
    }
}
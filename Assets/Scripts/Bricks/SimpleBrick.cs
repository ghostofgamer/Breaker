using UnityEngine;

namespace Bricks
{
    public class SimpleBrick : BrickCoordinator
    {
        [SerializeField] private BrickDestroyer _brickDestroyer;

        public override void Die()
        {
            BrickDie();
            _brickDestroyer.Destroy();
        }
    }
}
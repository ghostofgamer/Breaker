using UnityEngine;

namespace Bricks
{
    public class BrickDestroy : Brick
    {
        public override void Die()
        {
            Destroy();
        }
    }
}
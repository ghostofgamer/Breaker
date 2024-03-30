using Bricks;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class ElectricBall : MonoBehaviour
    {
        public void DestroyBrick(Brick brick)
        {
            BrickExplosion brickExplosion = brick.GetComponent<BrickExplosion>();

            if (brickExplosion != null)
                brickExplosion.Detonate();
            else
                brick.Die();
        }
    }
}
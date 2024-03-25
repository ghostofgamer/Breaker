using Bricks;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class ElectricBall : MonoBehaviour
    {
        public void DestroyBrick(Brick brick)
        {
            if (brick.GetComponent<BrickExplosion>())
                brick.GetComponent<BrickExplosion>().Detonate();
            else
                brick.Die();
        }
    }
}
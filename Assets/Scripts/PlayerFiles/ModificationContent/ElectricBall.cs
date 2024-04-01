using Bricks;
using UnityEngine;

namespace PlayerFiles.ModificationContent
{
    public class ElectricBall : MonoBehaviour
    {
        public void DestroyBrick(BrickCoordinator brickCoordinator)
        {
            BrickExplosion brickExplosion = brickCoordinator.GetComponent<BrickExplosion>();

            if (brickExplosion != null)
                brickExplosion.Detonate();
            else
                brickCoordinator.Die();
        }
    }
}
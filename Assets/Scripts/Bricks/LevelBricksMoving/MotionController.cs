using Statistics;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class MotionController : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroy += ChangeMotion;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroy -= ChangeMotion;
        }

        protected void ChangeMotion()
        {
        }
    }
}
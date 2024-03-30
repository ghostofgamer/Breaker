using Statistics;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class WorkChanger : MonoBehaviour
    {
        [SerializeField] private BrickCounter _brickCounter;

        protected bool IsWork { get; private set; } = true;

        private void OnEnable()
        {
            _brickCounter.AllBrickDestroyed += OnChangeMotion;
        }

        private void OnDisable()
        {
            _brickCounter.AllBrickDestroyed -= OnChangeMotion;
        }

        private void OnChangeMotion()
        {
            IsWork = false;
        }
    }
}
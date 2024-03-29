using System;
using UnityEngine;

namespace Statistics
{
    public class BrickCounter : MonoBehaviour
    {
        [SerializeField] private BonusCounter _bonusCounter;
        [SerializeField] private ScoreCounter _scoreCounter;

        private int _bricksSmashedCount;
        private int _score = 5;
        private bool _isRemainingActivated;

        public event Action AllBrickDestroyed;

        public event Action BricksDestructionHelping;

        public int RemainingAmountHelp { get; private set; } = 3;

        public int BrickCount { get; private set; }

        public void ChangeValue(int reward)
        {
            BrickCount--;
            _bricksSmashedCount++;
            _bonusCounter.AddBonus(reward);
            _scoreCounter.IncreaseScore(_score);

            if (BrickCount <= RemainingAmountHelp)
            {
                if (!_isRemainingActivated)
                {
                    BricksDestructionHelping?.Invoke();
                    _isRemainingActivated = true;
                }
            }

            CheckAliveBrickCount();
        }

        public void AddBricks(int bricksCount)
        {
            BrickCount++;
        }

        public void CheckAliveBrickCount()
        {
            if (BrickCount <= 0)
                AllBrickDestroyed?.Invoke();
        }

        public int GetAmountSmashed()
        {
            return _bricksSmashedCount;
        }
    }
}
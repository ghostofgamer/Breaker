using SaveAndLoad;
using UnityEngine;

namespace Statistics
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private BonusCounter _bonusCounter;

        private int _scoreValue;

        public void IncreaseScore(int score)
        {
            _scoreValue += score;
        }

        public int GetScore()
        {
            int scoreAmount = _scoreValue + _bonusCounter.GetBonus();
            return scoreAmount;
        }
    }
}
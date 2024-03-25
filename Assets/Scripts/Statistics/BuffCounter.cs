using UnityEngine;

namespace Statistics
{
    public class BuffCounter : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;

        private int _buffCount;
        private int _buffsCollected;
        private int _score = 15;

        public void CollectBuff()
        {
            _buffsCollected++;
            _scoreCounter.IncreaseScore(_score);
        }

        public void IncreaseBuffCount()
        {
            _buffCount++;
        }

        public void DecreaseBuffCount()
        {
            _buffCount--;
        }

        public string GetStatistic()
        {
            return _buffsCollected + "/" + _buffCount;
        }
    }
}
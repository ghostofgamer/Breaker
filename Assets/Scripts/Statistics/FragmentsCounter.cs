using UnityEngine;

namespace Statistics
{
    public class FragmentsCounter : MonoBehaviour
    {
        [SerializeField] private ScoreCounter _scoreCounter;

        private float _fragmentsCount;
        private float _fragmentsCollect;
        private int _score = 10;
        private int _factor = 100;
        private string _percent = "%";

        public void SetAmountFragments(int fragmentsCount)
        {
            _fragmentsCount += fragmentsCount;
        }

        public void FragmentsCollect()
        {
            _fragmentsCollect++;
            _scoreCounter.IncreaseScore(_score);
        }

        public string GetAmountFragmentsCollect()
        {
            return ((_fragmentsCollect / _fragmentsCount) * _factor).ToString("0") + _percent;
        }
    }
}
using TMPro;
using UnityEngine;

namespace Statistics
{
    public class FragmentsCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _fragmentsTxt;
        [SerializeField] private ScoreCounter _scoreCounter;

        private float _fragmentsCount;
        private float _fragmentsCollect;
        private int _score = 10;

        public void SetAmountFragments(int fragmentsCount)
        {
            _fragmentsCount += fragmentsCount;
            Show();
        }

        public void FragmentsCollect()
        {
            _fragmentsCollect++;
            _scoreCounter.IncreaseScore(_score);
            Show();
        }

        private void Show()
        {
            _fragmentsTxt.text = _fragmentsCollect.ToString() + " / " + _fragmentsCount.ToString();
        }

        public string GetAmountFragmentsCollect()
        {
            return ((_fragmentsCollect / _fragmentsCount) * 100).ToString("0") + "%";
        }
    }
}
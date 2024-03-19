using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace Statistics
{
    public class Score : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreTxt;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;

        private int _startScore;
        private int _score;

        private void Start()
        {
            _score = _load.Get(Save.Score, _startScore);

            if (_scoreTxt != null)
                Show();
        }

        public void Increase(int score)
        {
            _score += score;
            _save.SetData(Save.Score, _score);
        }

        private void Show()
        {
            _scoreTxt.text = _score.ToString();
        }
    }
}
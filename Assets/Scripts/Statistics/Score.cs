using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace Statistics
{
    public class Score : MonoBehaviour
    {
        private const string ScoreValue = "Score";

        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Save _save;
        [SerializeField] private Load _load;

        private int _startScore;
        private int _score;

        private void Start()
        {
            _score = _load.Get(ScoreValue, _startScore);

            if (_scoreText != null)
                Show();
        }

        public void Increase(int score)
        {
            _score += score;
            _save.SetData(ScoreValue, _score);
        }

        private void Show()
        {
            _scoreText.text = _score.ToString();
        }
    }
}
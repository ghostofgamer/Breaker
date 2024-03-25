using System.Collections.Generic;
using Bricks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Statistics
{
    public class BrickCounter : MonoBehaviour
    {
        [SerializeField] private BonusCounter _bonusCounter;
        [SerializeField] private TMP_Text _brickCountTxt;
        [SerializeField] private TMP_Text _brickSmashedTxt;
        [SerializeField] private ScoreCounter _scoreCounter;

        private int _bricksSmashedCount;
        private List<Brick> _bricks;
        private int _score = 5;
        private bool _isRemainingActivated;

        public event UnityAction AllBrickDestroy;
        public event UnityAction BricksDestructionHelp;

        public int RemainingAmountHelp { get; private set; } = 3;
        public int BrickCount { get; private set; }

        public void ChangeValue(int reward)
        {
            BrickCount--;
            _bricksSmashedCount++;
            _bonusCounter.AddBonus(reward);
            // ShowInfo();
            _scoreCounter.IncreaseScore(_score);

            if (BrickCount <= RemainingAmountHelp)
            {
                if (!_isRemainingActivated)
                {
                    BricksDestructionHelp?.Invoke();
                    _isRemainingActivated = true;
                }
            }

            TryVictory();
        }

        public void AddBricks(int bricksCount)
        {
            BrickCount++;
            // ShowInfo();
        }

        /*private void ShowInfo()
        {
            _brickCountTxt.text = BrickCount.ToString();
            _brickSmashedTxt.text = _bricksSmashedCount.ToString();
        }*/

        public void TryVictory()
        {
            if (BrickCount <= 0)
            {
                AllBrickDestroy?.Invoke();
            }
        }

        public string GetAmountSmashed()
        {
            return _bricksSmashedCount.ToString();
        }
    }
}
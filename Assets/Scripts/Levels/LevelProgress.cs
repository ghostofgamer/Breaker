using Enum;
using UnityEngine;

namespace Levels
{
    public class LevelProgress : Level
    {
        [SerializeField] private Level[] _nextLevel;
        [SerializeField] private EffectChanger _effectChanger;

        private LevelState _currentLevelState;
        
        public void SetLevels()
        {
            if (_nextLevel.Length > 0)
            {
                for (int i = 0; i < _nextLevel.Length; i++)
                {
                    _currentLevelState = _nextLevel[i].State;
                    
                    if (State == LevelState.Completed && _currentLevelState == LevelState.Completed)
                    {
                        _effectChanger.SetLine(i, PassedColor);
                        _effectChanger.LineMoveActivation(i);
                    }
                    else if (State >= LevelState.Unlocked && _currentLevelState >= LevelState.Unlocked)
                    {
                        _effectChanger.SetLine(i, State == LevelState.Completed ? PassedColor : NotPassedColor);
                    }
                    else
                    {
                        _effectChanger.SetLine(i, NotOpenColor);
                    }
                }
            }
        }
    }
}
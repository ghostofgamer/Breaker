using Enum;
using UnityEngine;

namespace Levels
{
    public class LevelProgress : Level
    {
        [SerializeField] private Level[] _nextLevel;
        [SerializeField] private EffectInstaller _effectInstaller;

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
                        _effectInstaller.SetLine(i, PassedColor);
                        _effectInstaller.LineMoveActivation(i);
                    }
                    else if (State >= LevelState.Unlocked && _currentLevelState >= LevelState.Unlocked)
                    {
                        _effectInstaller.SetLine(i, State == LevelState.Completed ? PassedColor : NotPassedColor);
                    }
                    else
                    {
                        _effectInstaller.SetLine(i, NotOpenColor);
                    }
                }
            }
        }
    }
}
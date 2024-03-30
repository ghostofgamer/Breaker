using Enum;
using UnityEngine;

namespace Levels
{
    public class LevelProgress : Level
    {
        [SerializeField] private Level[] _nextLevel;
        [SerializeField] private EffectInstaller _effectInstaller;

        public void SetLevels()
        {
            if (_nextLevel.Length > 0)
            {
                for (int i = 0; i < _nextLevel.Length; i++)
                {
                    if (State == LevelState.Completed && _nextLevel[i].State == LevelState.Completed)
                    {
                        _effectInstaller.SetLine(i, PassedColor);
                        _effectInstaller.LineMoveActivation(i);
                    }
                    else if ((State == LevelState.Unlocked && _nextLevel[i].State == LevelState.Unlocked) ||
                             (State == LevelState.Completed && _nextLevel[i].State == LevelState.Unlocked) ||
                             (State == LevelState.Unlocked && _nextLevel[i].State == LevelState.Completed))
                    {
                        _effectInstaller.SetLine(i, NotPassedColor);
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
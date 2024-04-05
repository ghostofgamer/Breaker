using Enum;
using UnityEngine;

namespace Levels
{
    public class LevelProgress : Level
    {
        // [SerializeField] private Level[] _nextLevel;
        // [SerializeField] private EffectChanger _effectChanger;

        private LevelState _currentLevelState;

        public void SetLevels()
        {
            if (NextLevel.Length > 0)
            {
                for (int i = 0; i < NextLevel.Length; i++)
                {
                    _currentLevelState = NextLevel[i].State;

                    if (State == LevelState.Completed && _currentLevelState == LevelState.Completed)
                    {
                        Debug.Log("1");
                        EffectChanger.SetLine(i, PassedColor);
                        EffectChanger.LineMoveActivation(i);
                    }
                    else if (State >= LevelState.Unlocked && _currentLevelState >= LevelState.Unlocked)
                    {
                        Debug.Log("136");
                        EffectChanger.SetLine(i, State == LevelState.Completed ? PassedColor : NotPassedColor);
                    }
                    else
                    {
                        Debug.Log("15");
                        EffectChanger.SetLine(i, NotOpenColor);
                    }
                }
            }
        }
    }
}
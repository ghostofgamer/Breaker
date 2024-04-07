using Enum;

namespace Levels
{
    public class LevelProgress : Level
    {
        private LevelState _currentLevelState;

        public void SetLevels(LevelState levelState)
        {
            if (NextLevel.Length > 0)
            {
                for (int i = 0; i < NextLevel.Length; i++)
                {
                    _currentLevelState = NextLevel[i].State;

                    if (levelState == LevelState.Completed && _currentLevelState == LevelState.Completed)
                    {
                        EffectChanger.SetLine(i, PassedColor);
                        EffectChanger.LineMoveActivation(i);
                    }
                    else if (levelState >= LevelState.Unlocked && _currentLevelState >= LevelState.Unlocked)
                    {
                        EffectChanger.SetLine(i, State == LevelState.Completed ? PassedColor : NotPassedColor);
                    }
                    else
                    {
                        EffectChanger.SetLine(i, NotOpenColor);
                    }
                }
            }
        }
    }
}
using Enum;
using Levels;
using SaveAndLoad;
using UnityEngine;

namespace Progress
{
    public class ProgressGame : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private LevelState[] _levelStates;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;
        [SerializeField] private LevelProgress[] _levelsProgress;

        private void Awake()
        {
            LoadProgress();
        }

        private void SaveProgress()
        {
            for (int i = 0; i < _levelStates.Length; i++)
                _save.SetData(Save.LevelStatus + (i + 1), (int)_levelStates[i]);
        }

        private void LoadProgress()
        {
            for (int i = 0; i < _levelStates.Length; i++)
                _levelStates[i] = (LevelState)_load.Get(Save.LevelStatus + (i + 1), 0);

            if (_levelStates[0] != LevelState.Completed)
            {
                _levelStates[0] = LevelState.Unlocked;
                SaveProgress();
            }

            CheckNextLevel();

            for (int i = 0; i < _levels.Length; i++)
                _levels[i].Init(_levelStates[i]);

            foreach (var level in _levelsProgress)
                level.SetLevels();
        }

        private void CheckNextLevel()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                if (_levelStates[i] == LevelState.Completed)
                {
                    if (_levels[i].NextLevel.Length > 0)
                    {
                        for (int j = 0; j < _levels[i].NextLevel.Length; j++)
                        {
                            if (_levelStates[_levels[i].NextLevel[j].Index] != LevelState.Completed)
                            {
                                _levelStates[_levels[i].NextLevel[j].Index] = LevelState.Unlocked;
                            }
                        }
                    }
                }
            }

            SaveProgress();
        }
    }
}
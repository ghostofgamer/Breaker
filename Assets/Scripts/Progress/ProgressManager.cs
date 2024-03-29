using Enum;
using Levels;
using SaveAndLoad;
using UnityEngine;

namespace Progress
{
    public class ProgressManager : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private LevelState[] _levelStates;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;

        private void Awake()
        {
            LoadProgress();
        }

        public void Complited(int index)
        {
            _levelStates[index] = LevelState.Completed;

            if (_levels[index].Nextlevel.Length > 0)
            {
                for (int i = 0; i < _levels[index].Nextlevel.Length; i++)
                    _levelStates[_levels[index].Nextlevel[i].Index] = LevelState.Unlocked;
            }

            SaveProgress();
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

            foreach (var level in _levels)
                level.SetLevels();
        }

        private void CheckNextLevel()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                if (_levelStates[i] == LevelState.Completed)
                {
                    if (_levels[i].Nextlevel.Length > 0)
                    {
                        for (int j = 0; j < _levels[i].Nextlevel.Length; j++)
                        {
                            if (_levelStates[_levels[i].Nextlevel[j].Index] != LevelState.Completed)
                            {
                                _levelStates[_levels[i].Nextlevel[j].Index] = LevelState.Unlocked;
                            }
                        }
                    }
                }
            }

            SaveProgress();
        }
    }
}
using Enum;
using Levels;
using SaveAndLoad;
using UI.Screens.LevelInfo;
using Unity.VisualScripting;
using UnityEngine;

namespace Progress
{
    public class ProgressManager : MonoBehaviour
    {
        [SerializeField] private Level[] _levels;
        [SerializeField] private LevelState[] _levelStates;
        [SerializeField] private LevelInfo[] _levelsInfo;
        [SerializeField] private Load _load;
        [SerializeField] private Save _save;

        private void Awake()
        {
            LoadProgress();
        }

        private void TestProgressLoad()
        {
            LoadProgress();

            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i].Init(_levelStates[i]);
            }

            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i].SetLevels();
            }
        }

        /*private void SetLevelInfo()
    {
        for (int i = 0; i < _levelsInfo.Length; i++)
        {
            if (_levelStates[i] == LevelState.Completed)
            {
                _levelsInfo[i].SelectComplitedInfo();
            }

            if (_levelStates[i] == LevelState.Unlocked)
            {
                
            }
        }
    }*/

        public void SaveProgress()
        {
            for (int i = 0; i < _levelStates.Length; i++)
            {
                // _save.SetData("LevelStatus" + i + 1, (int) _levelStates[i]);
                _save.SetData(Save.LevelStatus + (i + 1), (int) _levelStates[i]);
                /*Debug.Log("I " + i +_levelStates[i]);
                Debug.Log("I " + i +_levels[i].name);*/
            }
        }

        public void LoadProgress()
        {
            for (int i = 0; i < _levelStates.Length; i++)
            {
                _levelStates[i] = (LevelState) _load.Get(Save.LevelStatus + (i + 1), 0);
                // Debug.Log("LevelStatus" +(i + 1));
            }

            if (_levelStates[0] != LevelState.Completed)
            {
                _levelStates[0] = LevelState.Unlocked;
                SaveProgress();
                // _save.SetData("LevelStatus1", (int) _levelStates[0]);
            }

            /*for (int i = 0; i < _levelStates.Length; i++)
        {
            Debug.Log( _levelStates[i]);
        }*/

            CheckNextLevel();
        
            for (int i = 0; i < _levels.Length; i++)
            {
                _levels[i].Init(_levelStates[i]);
            }

            foreach (var level in _levels)
                level.SetLevels();

            // SetLevelInfo();
        }

        public void Complited(int index)
        {
            _levelStates[index] = LevelState.Completed;
            Debug.Log("ЛУВЛ " + _levels[index].name);
            Debug.Log("ЛУВЛ " + _levels[index].LevelState);
            // _save.SetData("LevelStatus" + index + 1, (int)_levelStates[index]);

            if (_levels[index].Nextlevel.Length > 0)
            {
                for (int i = 0; i < _levels[index].Nextlevel.Length; i++)
                {
                    _levelStates[_levels[index].Nextlevel[i].Index] = LevelState.Unlocked;
                    Debug.Log("имя " + _levels[index].name);
                    // _save.SetData("LevelStatus" + _levels[index].Nextlevel[i].Index + 1, (int)_levelStates[_levels[index].Nextlevel[i].Index]);
                }
            }

            SaveProgress();
            // TestProgressLoad();
            // SaveProgress();
        }

        private void CheckNextLevel()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                Debug.Log(_levelStates[i]);
                Debug.Log("I " + i +_levels[i].name);
                
                if (_levelStates[i] == LevelState.Completed)
                {
                    Debug.Log(i);
                    if (_levels[i].Nextlevel.Length > 0)
                    {
                        for (int j = 0; j < _levels[i].Nextlevel.Length; j++)
                        {
                            if (_levelStates[_levels[i].Nextlevel[j].Index] != LevelState.Completed)
                            {
                                _levelStates[_levels[i].Nextlevel[j].Index] = LevelState.Unlocked;
                                // _save.SetData("LevelStatus" + _levels[i].Nextlevel[j].Index + 1, (int)_levelStates[_levels[i].Nextlevel[j].Index]);
                            }
                            // _save.SetData("LevelStatus" + _levels[index].Nextlevel[i].Index + 1, (int)_levelStates[_levels[index].Nextlevel[i].Index]);
                        }
                    } 
                }
            }
        
            SaveProgress();
        }
    }
}
using Enum;
using SaveAndLoad;
using UnityEngine;

namespace Levels
{
    public class LockLevel : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private Load _load;
        [SerializeField] private Level _level;

        private LevelState _levelState;

        private void Start()
        {
            _levelState = (LevelState)_load.Get(Save.LevelStatus + _index, 0);

            if (_levelState == LevelState.Locked)
                _level.gameObject.SetActive(false);
            else
                gameObject.SetActive(false);
        }
    }
}
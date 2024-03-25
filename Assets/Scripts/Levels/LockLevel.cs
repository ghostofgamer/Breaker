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

        private void Start()
        {
            LevelState status = (LevelState) _load.Get(Save.LevelStatus + _index, 0);

            if (status == LevelState.Locked)
                _level.gameObject.SetActive(false);
            else
                gameObject.SetActive(false);
        }
    }
}
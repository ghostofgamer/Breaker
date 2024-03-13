using Enum;
using UnityEngine;

namespace Progress
{
    public class LevelData : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private LevelState _levelState;

        private void Start()
        {
        }
    }
}

using UI.Screens.LevelInfo;
using UnityEngine;

namespace Levels
{
    public class InfoLevelCloser : MonoBehaviour
    {
        [SerializeField] private LevelInfo[] _levelInfos;

        public void CloseAllScreen()
        {
            foreach (var levelInfo in _levelInfos)
            {
                if (levelInfo.IsOpen)
                {
                    levelInfo.Close();
                }
            }
        }
    }
}
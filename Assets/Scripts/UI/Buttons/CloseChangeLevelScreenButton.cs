using UI.Screens.LevelInfo;
using UnityEngine;

namespace UI.Buttons
{
    public class CloseChangeLevelScreenButton : AbstractButton
    {
        [SerializeField] private LevelInfo _levelInfo;

        protected override void OnClick()
        {
            _levelInfo.Close();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseChangeLevelScreenButton : AbstractButton
{
    [SerializeField] private LevelInfo _levelInfo;

    protected override void OnClick()
    {
        _levelInfo.Close();
    }
}

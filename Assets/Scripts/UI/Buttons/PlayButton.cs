using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    private const string SceneName = "Level1";         
    
    protected override void OnClick()
    {
        SceneManager.LoadScene(SceneName);
    }
}

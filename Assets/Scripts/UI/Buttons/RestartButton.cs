using System.Collections;
using System.Collections.Generic;
using UI.Buttons;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : AbstractButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

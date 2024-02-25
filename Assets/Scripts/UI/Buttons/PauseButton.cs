using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : AbstractButton
{
    private bool isPaused = false;

    
    protected override void OnClick()
    {
        isPaused = !isPaused;
        
        if (isPaused)
        {
            Time.timeScale = 0f; 
        }
        else
        {
            Time.timeScale = 1f; 
        }
    }
}

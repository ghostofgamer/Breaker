using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    [SerializeField]private WaveMotion _waveMotion;
    [SerializeField] private CanvasAnimator _canvasAnimator; 
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private WaitForSeconds _waitFor = new WaitForSeconds(0.16f);

    // private const string SceneName = "Level1";
    private const string SceneName = "ChooseLvlScene";

    protected override void OnClick()
    {
        // SceneManager.LoadScene(SceneName);
        StartCoroutine(BricksMove());
    }

    private IEnumerator BricksMove()
    {
        _canvasAnimator.Close();
        yield return _waitFor;
        _waveMotion.FlyBackAllCubes();
        yield return _waitForSeconds;  
        SceneManager.LoadScene(SceneName);     
    }
}

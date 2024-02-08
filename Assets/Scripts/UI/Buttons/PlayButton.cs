using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AbstractButton
{
    [SerializeField]private WaveMotion _waveMotion;
    [SerializeField] private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    private const string SceneName = "Level1";

    protected override void OnClick()
    {
        // SceneManager.LoadScene(SceneName);
        StartCoroutine(BricksMove());
    }

    private IEnumerator BricksMove()
    {
        _waveMotion.FlyBackAllCubes();
        yield return _waitForSeconds;  
        SceneManager.LoadScene(SceneName);     
    }
}

using System.Collections;
using System.Collections.Generic;
using GameScene;
using GameScene.BallContent;
using ModificationFiles;
using PlayerFiles.PlatformaContent;
using UnityEngine;

public class Reviver : MonoBehaviour
{
    [SerializeField] private PlatformaRevive _platformaRevive;
    [SerializeField] private NameEffectAnimation _reviveAnimation;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private BallRevive _ballRevive;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

    public void RevivePlatform()
    {
        StartCoroutine(ComeLife());
    }

    private IEnumerator ComeLife()
    {
        _reviveAnimation.Show();
        yield return _waitForSeconds;
        _sceneLoader.ShowActivation();
        yield return _waitForSeconds;
        _platformaRevive.GetLife();
        _ballRevive.Revive();
    }
}
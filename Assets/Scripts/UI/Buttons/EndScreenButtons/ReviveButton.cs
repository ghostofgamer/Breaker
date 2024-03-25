using System.Collections;
using System.Collections.Generic;
using ADS;
using GameScene;
using GameScene.BallContent;
using PlayerFiles.PlatformaContent;
using Statistics;
using UI.Screens.EndScreens;
using UnityEngine;

public class ReviveButton : AbstractButton
{
    [SerializeField] private BallRevive _ballRevive;
    [SerializeField] private PlatformaRevive _platformaRevive;
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private RewardRevive _rewardRevive;
    [SerializeField] private AudioSource _audioSource;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private Coroutine _coroutine;

    protected override void OnClick()
    {
        _audioSource.PlayOneShot(_audioSource.clip);

#if UNITY_WEBGL && !UNITY_EDITOR
           Button.interactable = false;
                   
                   _rewardRevive.Show();
#endif


#if UNITY_EDITOR
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Revive());
#endif
    }

    private IEnumerator Revive()
    {
        _reviveScreen.ChooseRevive();
        yield return _waitForSeconds;
        // _ballRevive.Revive();
        _sceneLoader.RevivePlatform();
        _brickCounter.TryVictory();
        // _platformaRevive.Revive();
    }
}
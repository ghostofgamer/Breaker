using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveButton : AbstractButton
{
    [SerializeField] private BallRevive _ballRevive;
    [SerializeField] private PlatformaRevive _platformaRevive;
    [SerializeField] private ReviveScreen _reviveScreen;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private BrickCounter _brickCounter;
    
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    private Coroutine _coroutine;
    
    protected override void OnClick()
    {
        if(_coroutine!=null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(Revive());
    }

    private IEnumerator Revive()
    {
        _reviveScreen.ChooseRevive();
        yield return _waitForSeconds;
        _ballRevive.Revive();
        _sceneLoader.RevivePlatform();
        _brickCounter.TryVictory();
        // _platformaRevive.Revive();
    }
}

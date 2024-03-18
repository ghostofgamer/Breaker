using System.Collections;
using System.Collections.Generic;
using GameScene;
using Statistics;
using TMPro;
using UnityEngine;

public class LuckySave : MonoBehaviour
{
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private TextLuckySaveMove _LuckySaveText;

    private float _bonusChances = 50;
    private float _randomValue;

    private WaitForSecondsRealtime _waitForSeconds = new WaitForSecondsRealtime(1f);
    private WaitForSecondsRealtime _waitForStart = new WaitForSecondsRealtime(0.3f);
    private Coroutine _coroutine;

    public bool TryGetLuckySave()
    {
        _randomValue = Random.Range(0, 100f);

        if (_randomValue > _bonusChances)
            return false;

        Activated();
        return true;
    }

    private void Activated()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ActivateExtraLife());
    }

    private IEnumerator ActivateExtraLife()
    {
        yield return _waitForStart;
        _LuckySaveText.gameObject.SetActive(true);
        _LuckySaveText.Play();
        yield return _waitForSeconds;
        _sceneLoader.RevivePlatform();
        _brickCounter.TryVictory();
    }
}
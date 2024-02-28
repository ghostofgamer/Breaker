using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LevelComplite : MonoBehaviour
{
    [SerializeField] private BrickCounter _brickCounter;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private ClaimButton _claimButton;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private SpawnBonusLevelComplite _spawnBonusLevelComplite;
    [SerializeField] private Animator _animator;

    private Vector3 _target;
    private bool _isVictory = false;
    private float _speed = 100f;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
    private WaitForSeconds _waitForSeconds1 = new WaitForSeconds(3f);

    private void OnEnable()
    {
        _brickCounter.AllBrickDestory += Victory;
    }

    private void OnDisable()
    {
        _brickCounter.AllBrickDestory -= Victory;
    }

    private void Start()
    {
        Vector3 position = transform.position;
        _target = new Vector3(_text.transform.position.x, _text.transform.position.y - 100f,
            _text.transform.position.z);
    }

    private void Update()
    {
        if (!_isVictory)
            return;

        if (_text.transform.position != _target)
            _text.transform.position = Vector3.MoveTowards(_text.transform.position, _target, _speed * Time.deltaTime);
    }

    private void SetValue()
    {
        gameObject.SetActive(true);
        _text.enabled = true;
        _isVictory = true;
    }

    private void Victory()
    {
        StartCoroutine(_OnVictory());
    }

    private IEnumerator _OnVictory()
    {
        SetValue();
        yield return _waitForSeconds;
        _claimButton.gameObject.SetActive(true);
        _animator.Play("EnviropmentRotate");
        yield return _waitForSeconds1;
        _spawnBonusLevelComplite.StartFlightBonuses();
        _claimButton.SetValue(_scoreCounter.GetScore() / 10);
    }
}
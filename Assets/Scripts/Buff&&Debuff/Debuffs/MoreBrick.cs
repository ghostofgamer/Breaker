using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBrick : Modification
{
    [SerializeField] private Transform _bricksContainer;
    [SerializeField] private float _amountBricks;
    [SerializeField] private GameObject _brickPrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _spawnPosition;

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            StartCoroutine(OnMoreBricksActivated());
        }
    }

    public override void StopModification()
    {
    }

    private IEnumerator OnMoreBricksActivated()
    {
        for (int i = 0; i < _amountBricks; i++)
        {
            Vector3 randomPoint = Random.insideUnitCircle * _spawnRadius;
            Vector3 spawnPosition = _spawnPosition.position + new Vector3(randomPoint.x, 0, randomPoint.y);
            GameObject cube = Instantiate(_brickPrefab, _bricksContainer);
            cube.transform.position = spawnPosition;
            cube.transform.localScale = Vector3.one;
            yield return WaitForSeconds;
        }
        
        Player.DeleteEffect(this);
    }
}
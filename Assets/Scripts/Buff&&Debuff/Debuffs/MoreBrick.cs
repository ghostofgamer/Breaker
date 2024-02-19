using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoreBrick : MonoBehaviour
{
    [SerializeField] private Transform _bricksContainer;
    [SerializeField] private float _amountBricks;
    [SerializeField] private GameObject _brickPrefab;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private Transform _spawnPosition;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.165f);

    public void MoreBricksActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnMoreBricksActivated(platformaMover));
    }
    
    private IEnumerator OnMoreBricksActivated(PlatformaMover platformaMover)
    {
        for (int i = 0; i < _amountBricks; i++)
        {
            Vector3 randomPoint = Random.insideUnitCircle * _spawnRadius;
            Vector3 spawnPosition = _spawnPosition.position + new Vector3(randomPoint.x, 0, randomPoint.y);
            GameObject cube = Instantiate(_brickPrefab, _bricksContainer);
            cube.transform.position = spawnPosition;
            cube.transform.localScale = Vector3.one;
            yield return _waitForSeconds;
        }
        
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }
}
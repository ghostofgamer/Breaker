using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : MonoBehaviour
{
    [SerializeField] private Transform _bricksContainer;
    [SerializeField] protected BuffType _buffType;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(10f);
    private List<Transform> _bricks;

    private void Start()
    {
        _bricks = new List<Transform>();
    }

    public void ImmuneBricksActivated(PlatformaMover platformaMover)
    {
        if (platformaMover.GetComponent<Platforma>().TryApplyEffect(_buffType))
            StartCoroutine(OnImmuneBricksActivated(platformaMover));
    }

    private IEnumerator OnImmuneBricksActivated(PlatformaMover platformaMover)
    {
        GetBricks(true);
        yield return _waitForSeconds;
        GetBricks(false);
        platformaMover.GetComponent<Platforma>().DeleteEffect(_buffType);
    }

    private void GetBricks(bool immortalBrick)
    {
        for (int i = 0; i < _bricksContainer.childCount; i++)
        {
            _bricks.Add(_bricksContainer.GetChild(i));
        }

        foreach (Transform brick in _bricks)
        {
            brick.GetComponent<BrickDestroy>().SetBoolImmortal(immortalBrick);
        }
    }
}
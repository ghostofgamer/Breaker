using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immune : Modification
{
    [SerializeField] private Transform _bricksContainer;

    private List<Transform> _bricks;

    protected override void Start()
    {
        base.Start();
        _bricks = new List<Transform>();
    }

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            Coroutine = StartCoroutine(OnImmuneBricksActivated());
        }
    }

    public override void StopModification()
    {
        Stop();
    }

    private IEnumerator OnImmuneBricksActivated()
    {
        GetBricks(true);
        yield return WaitForSeconds;
        Stop();
        Player.DeleteEffect(this);
    }

    private void GetBricks(bool immortalBrick)
    {
        for (int i = 0; i < _bricksContainer.childCount; i++)
            _bricks.Add(_bricksContainer.GetChild(i));

        foreach (Transform brick in _bricks)
            brick.GetComponent<BrickDestroy>().SetBoolImmortal(immortalBrick);
    }

    private void Stop()
    {
        GetBricks(false);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Immune : Modification
{
    [SerializeField] private Transform _bricksContainer;

    private List<Brick> _bricks;
    private List<Brick> _filtredBricks;

    protected override void Start()
    {
        base.Start();
        _bricks = new List<Brick>();
        _filtredBricks = new List<Brick>();
    }

    public override void ApplyModification()
    {
        if (Player.TryApplyEffect(this))
        {
            if (Coroutine != null)
                StopCoroutine(Coroutine);

            Coroutine = StartCoroutine(OnImmuneBricksActivated());
            ShowNameEffect();
        }
    }

    public override void StopModification()
    {
        ChangeBricksImmortal(false);
    }

    private IEnumerator OnImmuneBricksActivated()
    {
        SetList();
        ChangeBricksImmortal(true);
        yield return WaitForSeconds;
        ChangeBricksImmortal(false);
        Player.DeleteEffect(this);
    }

    private void ChangeBricksImmortal(bool immortalBrick)
    {
        SetActive(immortalBrick);

        foreach (Brick brick in _filtredBricks)
            brick.GetComponent<Brick>().SetBoolImmortal(immortalBrick);
    }

    private void SetList()
    {
        for (int i = 0; i < _bricksContainer.childCount; i++)
            _bricks.Add(_bricksContainer.GetChild(i).GetComponent<Brick>());

        _filtredBricks = _bricks.Where(p => p.IsImmortalFlag == false).ToList();
    }

    /*
    private void Stop()
    {
        GetBricks(false);
    }*/
}
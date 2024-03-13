using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Bricks;
using UnityEngine;

public class Immune : Modification
{
    [SerializeField] private Transform _bricksContainer;

    // private List<Brick> _bricks;
    // private List<Brick> _filtredBricks;

    private List<Transform> _bricks;
    private List<Transform> _filtredBricks;
    
    
    protected override void Start()
    {
        base.Start();
        // _bricks = new List<Brick>();
        // _filtredBricks = new List<Brick>();
        
        // _bricks = new List<Transform>();
        // _filtredBricks = new List<Transform>();
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

        // foreach (Brick brick in _filtredBricks)
        //     brick.GetComponent<Brick>().SetBoolImmortal(immortalBrick);
        
        foreach (Transform brick in _filtredBricks)
            brick.GetComponent<Brick>().SetBoolImmortal(immortalBrick);
    }

    private void SetList()
    {
        _bricks = new List<Transform>();
        _filtredBricks = new List<Transform>();
        
        for (int i = 0; i < _bricksContainer.childCount; i++)
            _bricks.Add(_bricksContainer.GetChild(i));
        
        _filtredBricks = _bricks
            .Where(p => p.gameObject.GetComponent<Brick>() && !p.gameObject.GetComponent<Brick>().IsEternal &&
                        p.gameObject.activeSelf == true).ToList();
        
        
        Debug.Log("ДО");
        
        
        // for (int i = 0; i < _bricksContainer.childCount; i++)
        //     _bricks.Add(_bricksContainer.GetChild(i).GetComponent<Brick>());
        //
        // _filtredBricks = _bricks.Where(p => p.IsImmortalFlag == false).ToList();
        //
        
Debug.Log(_filtredBricks.Count);

        // for (int i = 0; i < _filtredBricks.Count; i++)
        // {
        //     Debug.Log(_filtredBricks[i].name);
        // }
    }

    /*
    private void Stop()
    {
        GetBricks(false);
    }*/
}
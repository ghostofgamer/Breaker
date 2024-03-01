using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetModifications : Modification
{
    [SerializeField] private BallTrigger _ball;
    [SerializeField] private BrickCounter _brickCounter;

    private void OnEnable()
    {
        _ball.Dying += ApplyModification;
        _brickCounter.AllBrickDestory += ApplyModification;
    }

    private void OnDisable()
    {
        _ball.Dying -= ApplyModification;
        _brickCounter.AllBrickDestory -= ApplyModification;
    }

    public override void ApplyModification()
    {
        Debug.Log("Reset");
        List<Modification> modifications = Player.Modifications;

        if (modifications.Count > 0)
        {
            foreach (Modification modification in modifications)
                modification.StopModification();

            Player.ClearList();
        }
    }

    public override void StopModification()
    {
    }
}
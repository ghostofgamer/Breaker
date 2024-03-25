using System;
using System.Collections;
using System.Collections.Generic;
using GameScene.BallContent;
using ModificationFiles;
using Statistics;
using UnityEngine;

public class ResetModifications : Modification
{
    [SerializeField] private BallTrigger _ball;
    [SerializeField] private BrickCounter _brickCounter;

    private void OnEnable()
    {
        _ball.Dying += ApplyModification;
        _brickCounter.AllBrickDestroy += ApplyModification;
    }

    private void OnDisable()
    {
        _ball.Dying -= ApplyModification;
        _brickCounter.AllBrickDestroy -= ApplyModification;
    }

    public override void ApplyModification()
    {
        List<Modification> modifications = Player.Modifications;

        if (modifications.Count > 0)
        {
            foreach (Modification modification in modifications)
                modification.StopModification();

            Player.ClearList();
        }
        
        ShowNameEffect();
    }

    public override void StopModification()
    {
    }
}
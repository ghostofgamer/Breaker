using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BrickDestroy : Brick
{
    [SerializeField] private GameObject particleEffectPrefab;

    public override void Die()
    {
        Destroy();
    }

    private void Destroy()
    {
        if (IsImmortal)
            return;
        
        particleEffectPrefab.SetActive(true);
        particleEffectPrefab.transform.parent = null;

        GetBuff();

        BrickCounter.ChangeValue(Reward);
        GetBonus();
        gameObject.SetActive(false);
    }
}
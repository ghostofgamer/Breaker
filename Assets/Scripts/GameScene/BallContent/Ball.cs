using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private List<BuffType> _buffs = new List<BuffType>();

    public bool TryApplyEffect(BuffType buffType)
    {
        if (!_buffs.Contains(buffType))
        {
            _buffs.Add(buffType);
            return true;
        }

        return false;
    }

    public void DeleteEffect(BuffType buffType)
    {
        if (_buffs.Contains(buffType))
            _buffs.Remove(buffType);
    }
}

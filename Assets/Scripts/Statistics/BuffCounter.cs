using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuffCounter : MonoBehaviour
{
    [SerializeField] private BrickCounter _brickCounter;
    
    private int _buffCount;
    private int _buffsCollected;

    public void CollectBuff()
    {
        _buffsCollected++;
    }

    public void IncreaseBuffCount()
    {
        _buffCount++;
    }

    public string GetStatistic()
    {
        return _buffsCollected + "/" + _buffCount;
    }
}

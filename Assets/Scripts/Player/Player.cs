using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected List<BuffType> Buffs = new List<BuffType>();
    
    public bool TryApplyEffect(BuffType buffType)
    {
        if (!Buffs.Contains(buffType))
        {
            Buffs.Add(buffType);
            return true;
        }

        return false;
    }

    public void DeleteEffect(BuffType buffType)
    {
        if (Buffs.Contains(buffType))
            Buffs.Remove(buffType);
        // Show();
    }

    /*private void Show()
    {
        for (int i = 0; i < Buffs.Count; i++)
        {
            Debug.Log(Buffs[i]);
        }
    }*/
}

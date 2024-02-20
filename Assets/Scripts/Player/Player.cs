using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    // protected List<BuffType> Buffs = new List<BuffType>();
    private List<Modification> _modifications = new List<Modification>();

    // public List<BuffType> BuffsList => Buffs;
    public List<Modification> Modifications => _modifications;

    /*public bool TryApplyEffect(BuffType buffType)
    {
        if (!Buffs.Contains(buffType))
        {
            Buffs.Add(buffType);
            return true;
        }

        return false;
    }*/

    /*public List<Modification> GetModifications()
    {
        return _modifications;
    }*/

    public void ClearList()
    {
        _modifications.Clear();
    }
     
    public bool TryApplyEffect(Modification modification)
    {
        if (!_modifications.Contains(modification))
        {
            _modifications.Add(modification);
            return true;
        }

        return false;
    }

    public void DeleteEffect(Modification modification)
    {
        if (_modifications.Contains(modification))
            _modifications.Remove(modification);
        // Show();
    }

    /*public void DeleteEffect(BuffType buffType)
    {
        if (Buffs.Contains(buffType))
            Buffs.Remove(buffType);
        // Show();
    }*/

    /*private void Show()
    {
        for (int i = 0; i < Buffs.Count; i++)
        {
            Debug.Log(Buffs[i]);
        }
    }*/
}
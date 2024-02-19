using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetModifications : MonoBehaviour
{
    [SerializeField] private Player _player;
    
    public void Stop()
    {
        List<Modification> _modifications = _player.Modifications;

        foreach (Modification modification in _modifications)
        {
            modification.StopModification(_player);
        }
    }
}
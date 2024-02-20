using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetModifications : Modification
{
    public override void ApplyModification()
    {
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
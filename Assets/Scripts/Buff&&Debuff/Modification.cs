using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modification : MonoBehaviour
{
    [SerializeField] protected BuffType _buffType;

    protected abstract void ApplyModification();
}
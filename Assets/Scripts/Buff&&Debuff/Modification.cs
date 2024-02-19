using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Modification : MonoBehaviour
{
    [SerializeField] protected PlatformaMover PlatformaMover;
    [SerializeField] protected BallController  BallController;
    [SerializeField] protected BallPortalMover BallPortalMover;
    [SerializeField] protected Player Player;
    // [SerializeField] protected BuffType BuffType;

    public abstract void ApplyModification(Player player);
    
    public abstract void StopModification(Player player);
}
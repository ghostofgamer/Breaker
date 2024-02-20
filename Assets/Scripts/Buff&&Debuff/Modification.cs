using UnityEngine;

public abstract class Modification : MonoBehaviour
{
    [SerializeField] protected PlatformaMover PlatformaMover;
    [SerializeField] protected BallController  BallController;
    [SerializeField] protected BallPortalMover BallPortalMover;
    [SerializeField] protected Player Player;

    [SerializeField] private BuffType _buffType;
    [SerializeField] private float _duration;
    
    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;

    protected virtual void Start()
    {
        WaitForSeconds = new WaitForSeconds(_duration);
    }

    public abstract void ApplyModification();
    
    public abstract void StopModification();
}
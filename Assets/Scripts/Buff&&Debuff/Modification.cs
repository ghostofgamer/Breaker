using UnityEngine;
using UnityEngine.UI;

public abstract class Modification : MonoBehaviour
{
    [SerializeField] protected PlatformaMover PlatformaMover;
    [SerializeField] protected BallController  BallController;
    [SerializeField] protected BallPortalMover BallPortalMover;
    [SerializeField] protected Player Player;
    [SerializeField] protected float Duration;

    [SerializeField] private Image _image;
    [SerializeField] private BuffType _buffType;

    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;

    protected virtual void Start()
    {
        WaitForSeconds = new WaitForSeconds(Duration);
    }

    protected void SetActiveImage(bool isActive)
    {
        _image.gameObject.SetActive(isActive);  
    }
    
    public abstract void ApplyModification();
    
    public abstract void StopModification();
}
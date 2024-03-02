using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Modification : MonoBehaviour
{
    [SerializeField] protected PlatformaMover PlatformaMover;
    [SerializeField] protected BallController BallController;
    [SerializeField] protected BallMover _ballMover;
    [SerializeField] protected Player Player;
    [SerializeField] protected float Duration;
    [SerializeField] protected NameEffectAnimation NameEffect;

    [SerializeField] private BuffUIFade _buffUI;
    [SerializeField] private BuffType _buffType;

    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;

    private void Awake()
    {
        if (_buffUI != null)
            _buffUI.Init(Duration);
    }

    protected virtual void Start()
    {
        WaitForSeconds = new WaitForSeconds(Duration);
    }

    protected void SetActive(bool isActive)
    {
        // _buffUI.Init(Duration);
        _buffUI.gameObject.SetActive(isActive);
    }

    protected void ShowNameEffect()
    {
        NameEffect.Show();
    }

    public abstract void ApplyModification();

    public abstract void StopModification();
}
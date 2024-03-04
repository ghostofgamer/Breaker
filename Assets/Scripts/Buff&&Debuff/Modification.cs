using System;
using Enum;
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

    // [SerializeField] private Buffs _buffs;
    [SerializeField] private Load _load;
    [SerializeField] private bool _isImproving;
    [SerializeField] private BuffUIFade _buffUI;
    [SerializeField] private BuffType _buffType;

    protected Coroutine Coroutine;
    protected WaitForSeconds WaitForSeconds;
    
    private int _startIndex = 0;

    private void Awake()
    {
        if (_isImproving)
        {
            int number = _load.Get(_buffType.ToString(), _startIndex);

            if (number > _startIndex)
            {
                Duration *= 10.5f;
                Debug.Log(Duration);
            }
        }
        
        if (_buffUI != null)
            _buffUI.Init(Duration);
    }

    protected virtual void Start()
    {
        WaitForSeconds = new WaitForSeconds(Duration);
        // Debug.Log(Duration);
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
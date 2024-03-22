using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    private Button _button;
    private CanvasGroup _canvasGroup;
    
    protected Button Button => _button;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    protected virtual void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void OnDisable()
    {
        _button.onClick.RemoveListener(OnClick);
    }

    public void CanvasValue(int alpha)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = alpha > 0;
    }
    
    protected abstract void OnClick();
}

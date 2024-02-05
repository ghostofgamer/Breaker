using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class AbstractButton : MonoBehaviour
{
    private Button _button;
    private CanvasGroup _canvasGroup;
    
    private void Awake()
    {
        _button = GetComponent<Button>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnDisable()
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

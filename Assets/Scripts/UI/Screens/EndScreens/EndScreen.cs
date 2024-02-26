using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EndScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;

    public virtual void Open()
    {
        ChangeValue(1, true, true);
    }

    private void ChangeValue(int alpha, bool interactable, bool blockRaycast)
    {
        _canvasGroup.alpha = alpha;
        _canvasGroup.interactable = interactable;
        _canvasGroup.blocksRaycasts = blockRaycast;
    }
}
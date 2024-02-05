using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Knob : MonoBehaviour
{
    [SerializeField] private SwipeLayout _swipeLayout;

    public void OnKnobClicked(Button button)
    {
        _swipeLayout.OnKnobClicked(button);
    }
}
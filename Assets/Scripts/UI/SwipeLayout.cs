using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeLayout : MonoBehaviour
{
    [Range(1, 10)] [SerializeField] private int _transitionSpeed = 5;
    [Range(0, 1)] [SerializeField] private float _neighbourReductionPercentage = 0.5f;
    [SerializeField] private bool _scrollWhenReleazed = true;
    [Range(0.5f, 1)] [SerializeField] private float _scrollStopSpeed = 0.1f;
    [SerializeField] private Sprite[] _knobs;
    [SerializeField] private GameObject knob;
    [SerializeField] private Scrollbar _scrollbar;
    [SerializeField] private Transform _knobContainer;

    private Vector2 _neighBourScale;
    private Vector2 _mainScale;
    private float _scrollbarValue = 0;
    private float[] _attractionPoints;
    private float _subdivisionDistance;
    private float _attractionPoint;
    private int _childCount;
    private bool _knobClicked = false;

    private void Start()
    {
        _attractionPoints = new float[transform.childCount];
        _childCount = _attractionPoints.Length;
        _subdivisionDistance = 1f / (_childCount - 1f);

        for (int i = 0; i < _childCount; i++)
        {
            _attractionPoints[i] = _subdivisionDistance * i;
            Instantiate(knob, _knobContainer);
        }

        foreach (Transform child in transform)
        {
            child.localScale = new Vector2(_neighbourReductionPercentage, _neighbourReductionPercentage);
        }

        if (_childCount > 0)
        {
            _knobContainer.GetChild(0).GetComponent<Image>().sprite = _knobs[0];
            transform.GetChild(0).localScale = Vector2.one;
        }
    }

    private void Update()
    {
        if (!_knobClicked && (Input.GetMouseButton(0) || (_scrollWhenReleazed && GetScrollSpeed() > _scrollStopSpeed)))
        {
            _scrollbarValue = _scrollbar.value;
            FindAttractionPoint();
            UpdateUI();
        }
        else if (IsBeingScaled())
        {
            _scrollbar.value = Mathf.Lerp(_scrollbar.value, _attractionPoint, _transitionSpeed * Time.deltaTime);
            UpdateUI();
        }
        else
        {
            _knobClicked = false;
        }
    }

    private void FindAttractionPoint()
    {
        if (_scrollbarValue < 0)
            _attractionPoint = 0;
        else
        {
            for (int i = 0; i < _childCount; i++)
            {
                if (_scrollbarValue < _attractionPoints[i] +
                    (_subdivisionDistance / 2) && _scrollbarValue > _attractionPoints[i] -(_subdivisionDistance / 2))
                {
                    _attractionPoint = _attractionPoints[i];
                    break;
                }

                if (i == _childCount - 1)
                {
                    _attractionPoint = _attractionPoints[i];
                }
            }
        }
    }

    private void UpdateUI()
    {
        for (int i = 0; i < _attractionPoints.Length; i++)
        {
            if (_attractionPoints[i] == _attractionPoint)
            {
                _knobContainer.GetChild(i).GetComponent<Image>().sprite = _knobs[0];
                _mainScale = Vector2.Lerp(transform.GetChild(i).localScale, Vector2.one,
                    2 * _transitionSpeed * Time.deltaTime);
                transform.GetChild(i).localScale = _mainScale;
            }
            else
            {
                _knobContainer.GetChild(i).GetComponent<Image>().sprite = _knobs[1];
                _neighBourScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(_neighbourReductionPercentage, _neighbourReductionPercentage),2*_transitionSpeed * Time.deltaTime);
                transform.GetChild(i).localScale = _neighBourScale;
            }
        }
    }
    
    public void OnKnobClicked(Button button)
    {
        _knobClicked = true;
        Transform parent = button.transform.parent.transform;
        Transform pressedButton = button.transform;
        int i = 0;

        foreach (Transform child in parent)
        {
            if (child == pressedButton)
            {
                _attractionPoint = _attractionPoints[i];
                break;
            }

            i++;
        }
    }
    
    private float GetScrollSpeed()
    {
        return Mathf.Abs(_scrollbarValue - _scrollbar.value) / Time.deltaTime;
    }
    
    private bool IsBeingScaled()
    {
        return Mathf.Abs(_scrollbar.value - _attractionPoint) > 0.01f || _mainScale.x < 0.99f ||
               _neighBourScale.x > _neighbourReductionPercentage + 0.01f;
    }
}
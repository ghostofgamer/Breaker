using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffPerforming : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField]private float _duration = 1f;
    
    private float _targetHeight = 100f;
    private RectTransform _rectTransform;
    private float _elapsedTime = 0;
    private float _startHeight;
    
   private void Start()
    {
        _rectTransform = _image.GetComponent<RectTransform>();
        _startHeight = _rectTransform.rect.height;
        StartCoroutine(HeightImageChanged());
    }

   private IEnumerator HeightImageChanged()
   {
       while (_elapsedTime < _duration)
       {
           float newHeight = Mathf.Lerp(_startHeight, _targetHeight, _elapsedTime / _duration);
           _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, newHeight);
           _elapsedTime += Time.deltaTime;
           yield return null;
       }
       
       _rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, _targetHeight);
   }
}

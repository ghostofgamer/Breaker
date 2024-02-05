using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopBackGround : MonoBehaviour
{
    private float _duration = 0.165f;
    private Coroutine _coroutine;
    private void Start()
    {
        
    }
    
    public void BackGroundAlphaChange(int start, int end)
    {
        if(_coroutine!= null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(Fade(start,end));
    }

    private IEnumerator Fade(int startAlpha,int needAlpha)
    {
        float elapsedTime = 0f;
        CanvasGroup canvas = GetComponent<CanvasGroup>();

        if (canvas.alpha != needAlpha)
        {
            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, needAlpha, elapsedTime / _duration);
                canvas.alpha = alpha;
                Debug.Log("Alpha");
                yield return null;
            }
        }
    }
}

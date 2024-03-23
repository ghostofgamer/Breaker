using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveImages : MonoBehaviour
{
    public Image[] _images; 
    public float _speed = 1f; 
    public float _amplitude = 1f; 

    void Start()
    {
        StartCoroutine(Wave());
    }

    IEnumerator Wave()
    {
        while (true)
        {
            for (int i = 0; i < _images.Length; i++)
            {
                _images[i].rectTransform.anchoredPosition = new Vector2(_images[i].rectTransform.anchoredPosition.x, Mathf.Sin(Time.time * _speed + i) * _amplitude);
                yield return null;
            }
            
            yield return new WaitForSeconds(0.1f);
        }
    }
}

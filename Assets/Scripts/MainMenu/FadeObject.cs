using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FadeObject : MonoBehaviour
{
    private RectTransform _rectTransform;
    private float _fadeDuration = 0.3f;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        // StartCoroutine(Fade());
    }

    public void FadeOn()
    {
        StartCoroutine(Fade());
    }
    
    private IEnumerator Fade()
    {
        float elapsedTime = 0f;
        float originalWidth = _rectTransform.sizeDelta.x;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;    
            float newWight = Mathf.Lerp(originalWidth, 0f, elapsedTime / _fadeDuration);
            _rectTransform.sizeDelta = new Vector2(newWight, _rectTransform.sizeDelta.y);
            yield return null;
        }
    }
    public void FadeOut()
    {
        StartCoroutine(OnFadeOut());
    }
    private IEnumerator OnFadeOut()
    {
        float elapsedTime = 0f;
        float originalWidth = _rectTransform.sizeDelta.x;

        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;    
            float newWight = Mathf.Lerp(originalWidth, 599.63f, elapsedTime / _fadeDuration);
            _rectTransform.sizeDelta = new Vector2(newWight, _rectTransform.sizeDelta.y);
            yield return null;
        }
    }
    
}

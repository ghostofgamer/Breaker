using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class FadeObject : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    private RectTransform _rectTransform;
    private float _fadeDuration = 0.16f;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void FadeOn()
    {
        StartCoroutine(Fade());
    }
    
    private IEnumerator Fade()
    {
        _audioSource.PlayOneShot(_audioClip);
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
        _audioSource.PlayOneShot(_audioSource.clip);
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

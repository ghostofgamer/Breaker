using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectActivator : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    private WaitForSeconds _waitForSeconds = new WaitForSeconds(1.5f);
    private Coroutine _coroutine;
    
    public void Play()
    {
        if(_coroutine!=null)
            StopCoroutine(_coroutine);
        
        _coroutine = StartCoroutine(TemporarilyEnable());
    }

    public void Init(Vector3 position)
    {
        transform.position = position;
    }

    private IEnumerator TemporarilyEnable()
    {
        _effect.Play();
        yield return _waitForSeconds;
        gameObject.SetActive(false);
    }
}

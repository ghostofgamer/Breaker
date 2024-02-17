using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroy : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectPrefab;
    [SerializeField] private Effect _effect;

    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.TryGetComponent(out TestBall testBall))
        {
            gameObject.SetActive(false);
        }*/
        if (other.gameObject.TryGetComponent(out BallController chatHelp))
        {
            // Debug.Log("GameObject");
            // gameObject.SetActive(false);
        }
    }

    public void Destroy()
    {
        particleEffectPrefab.SetActive(true);
        particleEffectPrefab.transform.parent = null;
        /*_effect.transform.parent = null;
        _effect.gameObject.SetActive(true);*/
        if (_effect != null)
            Instantiate(_effect, transform.position, Quaternion.identity);

        gameObject.SetActive(false);
    }
}
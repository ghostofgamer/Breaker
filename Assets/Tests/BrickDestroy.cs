using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickDestroy : MonoBehaviour
{
    [SerializeField] private GameObject particleEffectPrefab;
    
    private void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.TryGetComponent(out TestBall testBall))
        {
            gameObject.SetActive(false);
        }*/
        if (other.gameObject.TryGetComponent(out ChatHelp chatHelp))
        {
            // Debug.Log("GameObject");
            // gameObject.SetActive(false);
        }
    }

    public void Destroy()
    {
        GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}

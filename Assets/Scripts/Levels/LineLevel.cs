using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLevel : MonoBehaviour
{
 public ParticleSystem particleSystem1;
    public ParticleSystem particleSystem2;
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Убедитесь, что обе системы частиц существуют
        if (particleSystem1 != null && particleSystem2 != null)
        {
            // Установите позиции LineRenderer на позиции систем частиц
            lineRenderer.SetPosition(0, particleSystem1.transform.position);
            lineRenderer.SetPosition(1, particleSystem2.transform.position);
        }
    }
}

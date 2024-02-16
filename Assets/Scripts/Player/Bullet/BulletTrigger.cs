using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out BrickDestroy brickDestroy))
        {
            brickDestroy.Destroy();
        }
    }
}

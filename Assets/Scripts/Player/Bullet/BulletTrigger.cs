using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        
        if (other.TryGetComponent(out BrickDestroy brickDestroy))
        {
            // Debug.Log("попал");
            brickDestroy.Destroy();
            
        }
    }
}

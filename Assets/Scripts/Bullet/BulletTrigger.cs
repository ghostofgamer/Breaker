using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _explosion;
    
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.TryGetComponent(out BrickDestroy brickDestroy))
        {
            brickDestroy.Destroy();
        }*/
        
        if (other.TryGetComponent(out Brick brick))
        {
            brick.Die();
            gameObject.SetActive(false);
        }
        
        if (other.TryGetComponent(out WallTrigger wallTrigger))
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}

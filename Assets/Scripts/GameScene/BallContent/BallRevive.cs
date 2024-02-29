using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRevive : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    
    public void Revive()
    {
        // gameObject.transform.position = new Vector3(0f,5.1f,0f);
        gameObject.transform.parent = _ball.PlatformaMover.transform;
        gameObject.transform.position = _ball.StartPosition.position;
        gameObject.SetActive(true);
        
        // GetComponent<Ball>().StopMove();
    }
}

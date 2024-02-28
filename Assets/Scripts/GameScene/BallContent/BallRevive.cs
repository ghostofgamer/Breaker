using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRevive : MonoBehaviour
{
    public void Revive()
    {
        gameObject.transform.position = new Vector3(0f,5.1f,0f); 
        gameObject.SetActive(true);
        // GetComponent<Ball>().StopMove();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4BrickMover : MonoBehaviour
{
   [SerializeField]private Transform _target1;
   [SerializeField]private Transform _target2;
   [SerializeField]private float _speed = 3f;
   
   private Transform _currentTarget;

    void Start()
    {
        _currentTarget = _target1;
    }

    void Update()
    {
        
        
        if (Vector3.Distance(transform.position, _currentTarget.position) < 0.1f)
        {
            if (_currentTarget == _target1)
            {
                _currentTarget = _target2;
            }
            else
            {
                _currentTarget = _target1;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget.position, _speed * Time.deltaTime);
    }
}

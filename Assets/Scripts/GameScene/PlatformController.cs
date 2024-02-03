using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private float _maxDistanceZ = -3f;
    private float _minDistanceZ = -7f;
    private float _DistanceX = 1f;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 6;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            worldPos.y = _rigidbody.position.y;
            worldPos.z = Mathf.Clamp(worldPos.z, _minDistanceZ, _maxDistanceZ);
            worldPos.x = Mathf.Clamp(worldPos.x, -_DistanceX, _DistanceX);
            Vector3 targetPosition = new Vector3(worldPos.x, worldPos.y, worldPos.z);
            _rigidbody.position = Vector3.Lerp(_rigidbody.position, targetPosition, _speed * Time.deltaTime);
        }

        /*float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        
        // Debug.Log("H = " + mouseX);
        Debug.Log("V = " + mouseY);
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(mouseX, 1, mouseY);
        _rigidbody.position = movement * _speed;*/
    }

    private void FixedUpdate()
    {
        /*float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        _rigidbody.velocity = movement * _speed;
        
        Debug.Log("H = " + moveHorizontal);*/
    }
}
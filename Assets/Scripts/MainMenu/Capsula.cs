using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Capsula : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    
    private Quaternion originalRotation;
    private Vector3 originalLocalRotation;
    private bool _isSelected = false;
    private Quaternion targetRotation;
    private Quaternion _originalRotation;

    private bool _rotate;

    void Start()
    {
        originalRotation = transform.rotation;
        // originalLocalRotation = transform.localRotation;
        // originalLocalRotation = transform.localEulerAngles;
        // targetRotation = originalRotation * Quaternion.Euler(45, 0, 0);
    }

    void Update()
    {
        if (_isSelected)
        {
            if (!_rotate)
            {
                transform.rotation = Quaternion.Euler(0, 0, 35);
                _rotate = true;


                if (Camera.main != null)
                {
                    float initialCapsuleAngleY = 30f;
                    float cameraAngle = Camera.main.transform.eulerAngles.x;
                    float capsuleAngle = cameraAngle - cameraAngle;
                    transform.eulerAngles = new Vector3(cameraAngle, capsuleAngle, 35f); 
                }
               
                
                
                
                
                
                
                
                /*// Получаем текущий угол поворота камеры вокруг оси X
                float cameraAngle = Camera.main.transform.eulerAngles.x;

                // Вычисляем угол поворота капсулы вокруг оси Y в соответствии с углом поворота камеры
                float capsuleAngle = cameraAngle;

                // Устанавливаем начальное положение капсулы
                transform.eulerAngles = new Vector3(0f, capsuleAngle, 0f);*/
            }

    
    
    // transform.Rotate(0, 65 * Time.deltaTime, 0, Space.World);

            
            
            _gameObject.GetComponent<RectTransform>().Rotate(Vector3.up * 65 * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * 10f);
            _rotate = false;
        }
    }

    public void StartRotate(bool selected)
    {
        _isSelected = selected;
    }

    /*
    private void Update()
    {
        // transform.rotation = Quaternion.Euler(0,0f,-45f);
        transform.Rotate(0, 150 * Time.deltaTime, 0, Space.World);
    }
    */
}
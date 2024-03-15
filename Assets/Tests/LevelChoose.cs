using System;
using System.Collections;
using System.Collections.Generic;
using Levels;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelChoose : MonoBehaviour
{
    [SerializeField]private Camera _mainCamera;
    [SerializeField]private LayerMask _targetLayerMask;
    [SerializeField]private float _maxDistance = 10f;
    [SerializeField]private KeyCode _keyToPress = KeyCode.Space;
    public LayerMask uiLayerMask;
    public LayerMask physicsLayerMask;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, uiLayerMask))
            {
                Debug.Log("UI");
                Debug.Log("Hit UI object: " + hit.transform.gameObject.name);
                // Добавьте здесь ваш код для обработки нажатия на физический объект
            }
            // Рейкаст для физических объектов
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, physicsLayerMask))
            {

                Debug.Log("Hit physics object: " + hit.transform.gameObject.name);
                // Добавьте здесь ваш код для обработки нажатия на физический объект
            }
            
            else
            {
                // Рейкаст для UI объектов
                PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
                pointerEventData.position = Input.mousePosition;

                List<RaycastResult> raycastResults = new List<RaycastResult>();
                EventSystem.current.RaycastAll(pointerEventData, raycastResults);

                if (raycastResults.Count > 0)
                {
                    Debug.Log("Hit UI object: " + raycastResults[0].gameObject.name);
                    // Добавьте здесь ваш код для обработки нажатия на UI объект
                }
            }
        }
        
        
        
        
//         
//         if (Input.GetMouseButtonDown(0))
//         {
//             Debug.Log("Жму");
//             RaycastHit hit;
//             Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
//
//             
//             if (Physics.Raycast(ray, out hit,Mathf.Infinity, _targetLayerMask))
//             {
//                 Debug.Log("Hit object: " + hit.transform.name);
//                 /*if (hit.transform.gameObject.GetComponent<Collider>() != null)
//                 {
//                     if (hit.collider.TryGetComponent(out Level level))
//                     {
//                         level.SelectLevel();
//                         Debug.Log("Hit object: " + hit.transform.name);
//                     }
//
//                     Debug.Log("Hit physics object: " + hit.transform.gameObject.name);
//                     // Добавьте здесь ваш код для обработки нажатия на физический объект
//                 }*/
//                 if (hit.collider.TryGetComponent(out Level level))
//                 {
//                     level.SelectLevel();
//                     Debug.Log("Hit object: " + hit.transform.name);
//                 }
//
//                 else if (hit.transform.gameObject.GetComponent<GraphicRaycaster>() != null)
//                 {
//                     PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
//                     pointerEventData.position = Input.mousePosition;
//
//                     List<RaycastResult> raycastResults = new List<RaycastResult>();
//                     hit.transform.gameObject.GetComponent<GraphicRaycaster>().Raycast(pointerEventData, raycastResults);
//
//                     if (raycastResults.Count > 0)
//                     {
//                         RaycastResult firstRaycastResult = raycastResults[0];
//                         Debug.Log("Hit UI object: " + firstRaycastResult.gameObject.name);
//                         // Добавьте здесь ваш код для обработки нажатия на UI элемент
//                     }
//                 }
//                 /*if (hit.collider.TryGetComponent(out Level level))
//                 {
//                     level.SelectLevel();
//                     Debug.Log("Hit object: " + hit.transform.name);
//                 }*/
//                 
//                 // Добавьте здесь ваш код для обработки нажатия на объект
//             }
//         }
    }
}

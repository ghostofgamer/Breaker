using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]private GameObject[] _objects;
    [SerializeField]private float _rotationTime = 6f;
    [SerializeField]private float _delayBetweenObjects = 1.65f;

    private WaitForSeconds _delay;
    private WaitForSeconds _delayRotaion;

    private void Start()
    {
        _delay = new WaitForSeconds(_delayBetweenObjects);
        _delayRotaion = new WaitForSeconds(_rotationTime);
        StartCoroutine(RotateObjects());
    }

    private IEnumerator RotateObjects()
    {
        while (true)
        {
            yield return _delay;
            
            for (int i = 0; i < _objects.Length; i++)
            {
                _objects[i].GetComponent<AccelerateRotate>().StartRotation();
                yield return _delay;
            }

            yield return _delayRotaion;

            for (int i = _objects.Length - 1; i >= 0; i--)
            {
                _objects[i].GetComponent<AccelerateRotate>().StopRotation();
                _objects[i].GetComponent<DecelerateStop>()
                    .StartDeceleration(_objects[i].GetComponent<AccelerateRotate>().MaxSpeed);
                
                yield return _delay;
            }

            
            
            /*// Раскручиваем объекты в прямом порядке
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<AccelerateRotate>().StartRotation();
                yield return delay;
            }

            // Ожидаем, пока все объекты не достигнут максимальной скорости
            yield return new WaitForSeconds(objects[0].GetComponent<AccelerateRotate>().accelerationTime);

            // Вращаем объекты на максимальной скорости
            yield return new WaitForSeconds(rotationTime);

            // Запоминаем порядок, в котором объекты были запущены
            int[] reverseOrder = new int[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                reverseOrder[i] = objects.Length - i - 1;
            }

            // Замедляем объекты в обратном порядке
            for (int i = 0; i < objects.Length; i++)
            {
                objects[reverseOrder[i]].GetComponent<DecelerateStop>().StartDeceleration(objects[reverseOrder[i]].GetComponent<AccelerateRotate>().maxSpeed);
                yield return delay;
            }

            // Ожидаем, пока все объекты не остановится
            yield return new WaitForSeconds(objects[0].GetComponent<DecelerateStop>().decelerationTime);*/
        }
    }
}
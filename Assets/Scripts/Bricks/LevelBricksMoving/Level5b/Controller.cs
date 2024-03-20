using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] objects;
    public float rotationTime = 5.0f;
    public float delayBetweenObjects = 1.0f;

    private WaitForSeconds delay;

    private void Start()
    {
        delay = new WaitForSeconds(delayBetweenObjects);
        StartCoroutine(RotateObjects());
    }

    private IEnumerator RotateObjects()
    {
        while (true)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].GetComponent<AccelerateRotate>().StartRotation();
                yield return delay;
            }

            yield return new WaitForSeconds(3f);

            for (int i = objects.Length - 1; i >= 0; i--)
            {
                objects[i].GetComponent<AccelerateRotate>().StopRotation();
                objects[i].GetComponent<DecelerateStop>()
                    .StartDeceleration(objects[i].GetComponent<AccelerateRotate>().maxSpeed);
                
                yield return delay;
            }

            yield return delay;
            
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
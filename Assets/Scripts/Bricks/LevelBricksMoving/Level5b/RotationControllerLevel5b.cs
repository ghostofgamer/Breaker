using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationControllerLevel5b : MonoBehaviour
{
    
        public GameObject[] objects; // Массив объектов, которые нужно раскручивать
    public float maxSpeed = 100.0f; // Максимальная скорость вращения
    public float accelerationTime = 2.0f; // Время разгона до максимальной скорости
    public float rotationTime = 5.0f; // Время вращения на максимальной скорости
    public float decelerationTime = 2.0f; // Время замедления до остановки
    public float delayBetweenObjects = 1.0f; // Задержка между запуском вращения объектов

    private WaitForSeconds delay; // Ожидание для корутины

    private void Start()
    {
        delay = new WaitForSeconds(delayBetweenObjects);
        StartCoroutine(RotateObjects());
    }

    private IEnumerator RotateObjects()
    {
        while (true)
        {
            // Раскручиваем объекты в прямом порядке
            for (int i = 0; i < objects.Length; i++)
            {
                StartCoroutine(AccelerateObject(objects[i], maxSpeed, accelerationTime));
                yield return delay;
            }

            // Ожидаем, пока все объекты не достигнут максимальной скорости
            yield return new WaitForSeconds(accelerationTime);

            // Вращаем объекты на максимальной скорости
            yield return new WaitForSeconds(rotationTime);

            /*
            // Запоминаем порядок, в котором объекты были запущены
            int[] reverseOrder = new int[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            {
                reverseOrder[i] = objects.Length - i - 1;
            }
            */

            /*// Замедляем объекты в обратном порядке
            for (int i = 0; i < objects.Length; i++)
            {
                StartCoroutine(DecelerateObject(objects[reverseOrder[i]], decelerationTime));
                yield return delay;
            }*/
            
            
            for (int i = objects.Length-1; i >= 0; i--)
            {
                Debug.Log(i);
                StartCoroutine(DecelerateObject(objects[i], decelerationTime));
                yield return delay;
            }

            // Ожидаем, пока все объекты не остановится
            yield return new WaitForSeconds(decelerationTime);
        }
    }

    private IEnumerator AccelerateObject(GameObject obj, float targetSpeed, float accelerationTime)
    {
        float currentSpeed = 0.0f;
        float acceleration = targetSpeed / accelerationTime;

        while (currentSpeed < targetSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator DecelerateObject(GameObject obj, float decelerationTime)
    {
        float currentSpeed = maxSpeed;
        float deceleration = maxSpeed / decelerationTime;

        while (currentSpeed > 0.0f)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }
    }
    
    
    
    
    
    
    
    
    
    
    

        /*
        public GameObject[] objects; // Массив объектов, которые нужно раскручивать
    public float maxSpeed = 100.0f; // Максимальная скорость вращения
    public float accelerationTime = 2.0f; // Время разгона до максимальной скорости
    public float rotationTime = 5.0f; // Время вращения на максимальной скорости
    public float decelerationTime = 2.0f; // Время замедления до остановки
    public float delayBetweenObjects = 1.0f; // Задержка между запуском вращения объектов

    private WaitForSeconds delay; // Ожидание для корутины

    private void Start()
    {
        delay = new WaitForSeconds(delayBetweenObjects);
        StartCoroutine(RotateObjects());
    }

    private IEnumerator RotateObjects()
    {
        while (true)
        {
            // Раскручиваем объекты в прямом порядке
            for (int i = 0; i < objects.Length; i++)
            {
                StartCoroutine(RotateObject(objects[i], maxSpeed, accelerationTime, rotationTime, decelerationTime));
                yield return delay;
            }
            
            // Ожидаем, пока все объекты не закончат вращаться
            yield return new WaitForSeconds(rotationTime + decelerationTime);
        }
    }

    private IEnumerator RotateObject(GameObject obj, float targetSpeed, float accelerationTime, float rotationTime, float decelerationTime)
    {
        float currentSpeed = 0.0f;
        float acceleration = targetSpeed / accelerationTime;
        float deceleration = targetSpeed / decelerationTime;
        float rotationTimer = 0.0f;

        while (currentSpeed < targetSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }

        rotationTimer = 0.0f;
        
        while (rotationTimer < rotationTime)
        {
            obj.transform.Rotate(Vector3.up, targetSpeed * Time.deltaTime);
            rotationTimer += Time.deltaTime;
            yield return null;
        }

        /*
        while (currentSpeed > 0.0f)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }#1#
    }*/








    /*
    public GameObject[] objects; // Массив объектов, которые нужно раскручивать
    public float maxSpeed = 100.0f; // Максимальная скорость вращения
    public float accelerationTime = 2.0f; // Время разгона до максимальной скорости
    public float rotationTime = 5.0f; // Время вращения на максимальной скорости
    public float decelerationTime = 2.0f; // Время замедления до остановки
    public float delayBetweenObjects = 1.0f; // Задержка между запуском вращения объектов

    private WaitForSeconds delay; // Ожидание для корутины

    private void Start()
    {
        delay = new WaitForSeconds(delayBetweenObjects);
        StartCoroutine(RotateObjects());
    }

    private IEnumerator RotateObjects()
    {
        while (true)
        {
            // Раскручиваем объекты в прямом порядке
            for (int i = 0; i < objects.Length; i++)
            {
                StartCoroutine(RotateObject(objects[i], maxSpeed, accelerationTime, rotationTime, decelerationTime));
                yield return delay;
            }

            // Ожидаем, пока все объекты не закончат вращаться
            yield return new WaitForSeconds(rotationTime + decelerationTime);

            /#1#/ Раскручиваем объекты в обратном порядке
            for (int i = objects.Length - 1; i >= 0; i--)
            {
                StartCoroutine(RotateObject(objects[i], -maxSpeed, accelerationTime, rotationTime, decelerationTime));
                yield return delay;
            }#1#

            // Ожидаем, пока все объекты не закончат вращаться в обратную сторону
            // yield return new WaitForSeconds(rotationTime + decelerationTime);
        }
    }

    private IEnumerator RotateObject(GameObject obj, float targetSpeed, float accelerationTime, float rotationTime, float decelerationTime)
    {
        float currentSpeed = 0.0f;
        float acceleration = targetSpeed / accelerationTime;
        float deceleration = targetSpeed / decelerationTime;
        float rotationTimer = 0.0f;

        while (currentSpeed < targetSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }

        rotationTimer = 0.0f;
        while (rotationTimer < rotationTime)
        {
            obj.transform.Rotate(Vector3.up, targetSpeed * Time.deltaTime);
            rotationTimer += Time.deltaTime;
            yield return null;
        }

        while (currentSpeed > 0.0f)
        {
            currentSpeed -= deceleration * Time.deltaTime;
            obj.transform.Rotate(Vector3.up, currentSpeed * Time.deltaTime);
            yield return null;
        }
    }*/
}

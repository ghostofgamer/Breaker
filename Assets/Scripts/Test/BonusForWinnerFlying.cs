using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusForWinnerFlying : MonoBehaviour
{
    public Image startImage; // Начальный Image
    public Image endImage; // Конечный Image
    public float speed = 1.0f; // Скорость движения

    private RectTransform rectTransform; // RectTransform объекта, который вы хотите двигать
    private float journeyLength; // Длина пути между начальной и конечной позицией
    private float startTime; // Время начала движения
    private Vector3 startPosition;
    public float radius = 50f;
    private float _elapsedTime;
    private float _duration = 10f;
    
    
    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Получаем RectTransform объекта
        startTime = Time.time; // Запоминаем время начала движения

        // Вычисляем длину пути между начальной и конечной позицией
        journeyLength = Vector3.Distance(startImage.GetComponent<RectTransform>().position, endImage.GetComponent<RectTransform>().position);
        StartCoroutine(Go());
        // startPosition = startImage.GetComponent<RectTransform>().position;
        /*Vector2 randomPoint = Random.insideUnitCircle * radius;
        startPosition = new Vector3(startPosition.x,startPosition.y+randomPoint.y,startPosition.z);*/
        
    }

    /*void Update()
    {
        // Вычисляем расстояние, которое нужно пройти за кадр
        float distCovered = (Time.time - startTime) * speed;

        // Вычисляем доля пути, которую нужно пройти за кадр
        float fractionOfJourney = distCovered / journeyLength;

        // Вычисляем новую позицию объекта с использованием Lerp
        rectTransform.position = Vector3.Slerp(startImage.GetComponent<RectTransform>().position, endImage.GetComponent<RectTransform>().position, fractionOfJourney);

        // Если объект достиг конечной позиции, сбрасываем время начала движения
        if (rectTransform.position == endImage.GetComponent<RectTransform>().position)
        {
            startTime = Time.time;
            Debug.Log("фвфвфвфвыфвфв");
        }
        
    }*/

    private IEnumerator Go()
    {
        _elapsedTime = 0;
        
        while (_elapsedTime<_duration)
        {
            _elapsedTime += Time.deltaTime;
            rectTransform.position = Vector3.Slerp(startImage.GetComponent<RectTransform>().position, endImage.GetComponent<RectTransform>().position, _elapsedTime/_duration);
            yield return null;
        }

        rectTransform.position = endImage.GetComponent<RectTransform>().position;
    }
    
    
    
    
    
    
    
    
    
    /*public Image startImage; // Начальный Image
    public Image endImage; // Конечный Image
    public float speed = 1.0f; // Скорость движения

    private RectTransform rectTransform; // RectTransform объекта, который вы хотите двигать

    void Start()
    {
        rectTransform = GetComponent<RectTransform>(); // Получаем RectTransform объекта
    }

    void Update()
    {
        // Получаем позиции начального и конечного Image
        Vector3 startPosition = startImage.GetComponent<RectTransform>().position;
        Vector3 endPosition = endImage.GetComponent<RectTransform>().position;

        // Вычисляем новую позицию объекта с использованием Lerp
        float t = Mathf.PingPong(Time.time * speed, 1.0f); // Функция PingPong создает эффект движения в обе стороны
        rectTransform.position = Vector3.Lerp(startPosition, endPosition, t);
    }*/
    
    
    
    
    
    
    
    
    /*private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        SetPosition();
    }

    void SetPosition()
    {
        // Получаем разрешение экрана
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // Устанавливаем позицию слева за экраном
        rectTransform.anchoredPosition = new Vector2(-screenWidth / 2, screenHeight / 2);
        Debug.Log(-screenWidth / 2);
    }
    */
    
    
    /*[SerializeField] private Transform endPosition; 
    // Конечная позиция бонуса
    public GameObject bonusPrefab; // Префаб бонуса
    public Button button; // Кнопка для растворения бонуса
    public RectTransform canvasRectTransform; // RectTransform канваса

    private RectTransform bonusRectTransform; // RectTransform бонуса
    private Vector2 startPosition; // Начальная позиция бонуса
    private float animationTime = 1.0f;
    void Start()
    {
        // Инициализация начальной и конечной позиций
        // startPosition = new Vector2(-Screen.width / 2, -Screen.height / 2);
        // endPosition = new Vector2(Screen.width / 2, -Screen.height / 2);
        //
        // // Создание бонуса
        // GameObject bonus = Instantiate(bonusPrefab, canvasRectTransform);
        // bonusRectTransform = bonus.GetComponent<RectTransform>();
        // bonusRectTransform.anchoredPosition = startPosition;

        // Подписка на событие нажатия кнопки
        button.onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick()
    {
        Debug.Log("высота " + Screen.height);
        Debug.Log("ширина " + Screen.width);
        Debug.Log("ПолВысоты " + Screen.height / 2);
        Debug.Log("ПолШирины "+ Screen.width/2);
        
        startPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        Debug.Log("старт позитион " + startPosition);
        Debug.Log("endPosition " + endPosition.position);

        // Создание бонуса
        GameObject bonus = Instantiate(bonusPrefab, canvasRectTransform);
        bonusRectTransform = bonus.GetComponent<RectTransform>();
        bonusRectTransform.anchoredPosition = startPosition;
        // Запуск корутины движения бонуса
        StartCoroutine(MoveBonus());
    }

    
    
    IEnumerator MoveBonus()
    {
        // Время начала анимации
        float elapsedTime = 0;

        // Движение бонуса по полукругу
        while (elapsedTime < animationTime)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationTime;
            float x = Mathf.Lerp(startPosition.x, endPosition.position.x, t);
            float y = Mathf.Lerp(startPosition.y, endPosition.position.y, t);

            // Создание эллиптического пути
            float angle = Mathf.Lerp(0, Mathf.PI, t);
            float radius = Vector2.Distance(startPosition, endPosition.position) / 2;
            float a = radius * Mathf.Cos(angle);
            float b = radius * Mathf.Sin(angle);

            bonusRectTransform.anchoredPosition = new Vector2(x + a, y + b);
            yield return null;
        }

        // Удаление бонуса после достижения конечной позиции
        // Destroy(bonusRectTransform.gameObject);
    }*/
    
    /*IEnumerator MoveBonus()
    {
        // Движение бонуса от начальной до конечной позиции
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime;
            bonusRectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        // Удаление бонуса после достижения конечной позиции
        Destroy(bonusRectTransform.gameObject);
    }*/
    
    
    
    
    /*public GameObject bonusPrefab; // Префаб бонуса
    public Button button; // Кнопка для растворения бонуса
    public RectTransform canvasRectTransform; // RectTransform канваса

    private RectTransform bonusRectTransform; // RectTransform бонуса
    private Vector2 startPosition; // Начальная позиция бонуса
    private Vector2 endPosition; // Конечная позиция бонуса
    private float animationTime = 1.0f; // Время анимации

    void Start()
    {
        // Инициализация начальной и конечной позиций
        startPosition = new Vector2(-Screen.width / 2, -Screen.height / 2);
        endPosition = new Vector2(Screen.width / 2, -Screen.height / 2);

        // Подписка на событие нажатия кнопки
        button.onClick.AddListener(Go);
    }

    public void Go()
    {
        // Создание бонуса
        GameObject bonus = Instantiate(bonusPrefab, canvasRectTransform);
        bonusRectTransform = bonus.GetComponent<RectTransform>();
        bonusRectTransform.anchoredPosition = startPosition;

        // Запуск корутины движения бонуса
        StartCoroutine(MoveBonus());
    }

    IEnumerator MoveBonus()
    {
        // Время начала анимации
        float startTime = Time.time;

        // Движение бонуса по полукругу
        while (Time.time - startTime < animationTime)
        {
            float t = (Time.time - startTime) / animationTime;
            float x = Mathf.Lerp(startPosition.x, endPosition.x, t);
            float y = Mathf.Lerp(startPosition.y, endPosition.y, t);

            // Создание эллиптического пути
            float angle = Mathf.Lerp(0, Mathf.PI, t);
            float radius = Vector2.Distance(startPosition, endPosition) / 2;
            float a = radius * Mathf.Cos(angle);
            float b = radius * Mathf.Sin(angle);

            bonusRectTransform.anchoredPosition = new Vector2(x + a, y + b);
            yield return null;
        }

        // Удаление бонуса после достижения конечной позиции
        Destroy(bonusRectTransform.gameObject);
    }*/
}

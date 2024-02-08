using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveMotion : MonoBehaviour
{
    public GameObject cubePrefab; // Префаб для кубов
    public float waveSpeed = 1.0f; // Скорость волны
    public float waveHeight = 1.0f; // Высота волны
    public float cubeSpacing = 1.5f; // Расстояние между кубами
    public int gridSize = 5; // Размер сетки (количество рядов и кубов в каждом ряду)
    public float spawnDelay = 1.0f; // Задержка между появлением рядов кубов
    public Vector3 startPosition; // Начальная позиция для появления сетки кубов

    private GameObject[,] cubeGrid; // Массив для хранения ссылок на созданные кубы
    public KeyCode flyBackKey = KeyCode.Space;

    private List<GameObject> cubeList;
    public float minFlySpeed = 1.0f; // Минимальная скорость полета кубов
    public float maxFlySpeed = 3.0f;
    void Start()
    {
        cubeList = new List<GameObject>();
        // Инициализация массива для хранения ссылок на кубы
        cubeGrid = new GameObject[gridSize, gridSize];

        // Запуск корутины для появления рядов кубов
        StartCoroutine(SpawnCubeRows());
    }

    IEnumerator SpawnCubeRows()
    {
        // Создаем ряды кубов с задержкой
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = startPosition + new Vector3(j * cubeSpacing, i * cubeSpacing, 0);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cubeGrid[i, j] = cube;
                cubeList.Add(cube);
            }

            // Ждем заданное время перед созданием следующего ряда
            yield return null;
        }
    }

    void Update()
    {
        // Обновляем позиции кубов в сетке
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cubeGrid[i, j] != null)
                {
                    float waveOffset = Mathf.Sin((Time.time + (i + j)) * waveSpeed) * waveHeight;
                    Vector3 newPosition = cubeGrid[i, j].transform.position + new Vector3(0, 0, waveOffset);
                    cubeGrid[i, j].transform.position = newPosition;
                }
            }
        }

        /*if (Input.GetKeyDown(flyBackKey))
        {
            FlyBackAllCubes();
            Debug.Log(cubeList.Count);
        }*/
    }
// Проверяем, была ли нажата клавиша для запуска кубов в обратном направлении


   public void FlyBackAllCubes()
    {
        Debug.Log("FlyBackAllCubes");
        // Запускаем все кубы в обратном направлении с разной скоростью
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i] != null)
            {
                float flySpeed = Random.Range(minFlySpeed, maxFlySpeed);
                StartCoroutine(FlyBackCube(cubeList[i], flySpeed));
            }
        }
    }

    IEnumerator FlyBackCube(GameObject cube, float speed)
    {
        Vector3 startPosition = cube.transform.position;
        Vector3 endPosition = startPosition - new Vector3(0, 0, -10); // Кубы полетают назад на 10 единиц по оси Z
        float flyTime = 1.0f / speed; // Время полета куба в зависимости от его скорости
        float elapsedTime = 0;

        while (elapsedTime < flyTime)
        {
            cube.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / flyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Удаляем куб после полета
        cubeList.Remove(cube);
        Destroy(cube);
    }


    /*public GameObject cubePrefab; // Префаб для кубов
    public float waveSpeed = 1.0f; // Скорость волны
    public float waveHeight = 1.0f; // Высота волны
    public float cubeSpacing = 1.5f; // Расстояние между кубами
    public int gridSize = 5; // Размер сетки (количество рядов и кубов в каждом ряду)

    private GameObject[,] cubeGrid; // Массив для хранения ссылок на созданные кубы

    void Start()
    {
        // Инициализация массива для хранения ссылок на кубы
        cubeGrid = new GameObject[gridSize, gridSize];

        // Создаем сетку из кубов
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = new Vector3(i * cubeSpacing, j * cubeSpacing, 0);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cubeGrid[i, j] = cube;
            }
        }
    }

    void Update()
    {
        // Обновляем позиции кубов в сетке
        for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                if (cubeGrid[i, j] != null)
                {
                    float waveOffset = Mathf.Sin((Time.time + (i + j)) * waveSpeed) * waveHeight;
                    Vector3 newPosition = cubeGrid[i, j].transform.position + new Vector3(0, 0, waveOffset);
                    cubeGrid[i, j].transform.position = newPosition;
                }
            }
        }
    }*/


    /*
    public GameObject cubePrefab; // Префаб для кубов
    public float waveSpeed = 1.0f; // Скорость волны
    public float waveHeight = 1.0f; // Высота волны
    public float cubeSpacing = 1.5f; // Расстояние между кубами
    public int squareSize = 5; // Размер квадрата (количество рядов и кубов в каждом ряду)
    public int waveCount = 3; // Количество волн

    private GameObject[,] cubeSquares; // Массив для хранения ссылок на созданные кубы

    void Start()
    {
        // Инициализация массива для хранения ссылок на кубы
        cubeSquares = new GameObject[squareSize, squareSize];

        // Создаем квадрат из кубов
        for (int i = 0; i < squareSize; i++)
        {
            for (int j = 0; j < squareSize; j++)
            {
                Vector3 position = new Vector3(i * cubeSpacing, 0, j * cubeSpacing);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cubeSquares[i, j] = cube;
            }
        }
    }

    void Update()
    {
        // Обновляем позиции кубов в квадрате
        for (int i = 0; i < squareSize; i++)
        {
            for (int j = 0; j < squareSize; j++)
            {
                if (cubeSquares[i, j] != null)
                {
                    float waveOffset = 0.0f;
                    for (int k = 0; k < waveCount; k++)
                    {
                        float waveFrequency = (k + 1) * waveSpeed;
                        float wavePhase = (i + j) * 0.1f * (k + 1);
                        waveOffset += Mathf.Sin((Time.time + wavePhase) * waveFrequency) * waveHeight / (k + 1);
                    }
                    Vector3 newPosition = cubeSquares[i, j].transform.position + new Vector3(0, waveOffset, 0);
                    cubeSquares[i, j].transform.position = newPosition;
                }
            }
        }
    }*/


    /*[SerializeField] private float _speed = 1f;
    [SerializeField] private float _amplitude = 1f;

    private Vector3 _initialPosition;

    private void Start()

    {
        _initialPosition = transform.position;
        _amplitude = Random.Range(3f, 5f);
    }
    private void Update()
    {
        float z = Mathf.Sin(Time.time * _speed) * _amplitude;
        transform.position = new Vector3(_initialPosition.x, _initialPosition.y, _initialPosition.z + z);
    }*/
}
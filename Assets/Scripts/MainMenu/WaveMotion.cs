using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveMotion : MonoBehaviour
{
    public GameObject cubePrefab;
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
    
    public int columns = 50;
    public int rows = 50;

    private GameObject[,] cubes;
    private Vector3[,] startPositions;
    private Vector3[,] endPositions;
    private float[,] waveSpeeds;
    private float time;

    private bool _isFlyOver = false;

    void Start()
    {
        cubeList = new List<GameObject>();
        // cubeGrid = new GameObject[gridSize, gridSize];
        cubeGrid = new GameObject[columns, rows];

        /*for (int i = 0; i < gridSize; i++)
        {
            for (int j = 0; j < gridSize; j++)
            {
                Vector3 position = startPosition - new Vector3(i * cubeSpacing, j * cubeSpacing, 0);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cubeGrid[i, j] = cube;
                cubeList.Add(cube);
            }
        }*/
        
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 position = startPosition - new Vector3(i * cubeSpacing, j * cubeSpacing, 0);
                GameObject cube = Instantiate(cubePrefab, position, Quaternion.identity);
                cubeGrid[i, j] = cube;
                cubeList.Add(cube);
            }
        }

        StartCoroutine(MoveCubes());
    }

    IEnumerator MoveCubes()
    {
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                Vector3 startPosition = cubeGrid[i, j].transform.position;
                Vector3 endPosition = startPosition - new Vector3(0, 0, 15);
                float speed = Random.Range(minFlySpeed, maxFlySpeed);
                StartCoroutine(MoveCube(cubeGrid[i, j], endPosition, speed));
            }
            yield return null;
        }

        yield return new WaitForSeconds(0.3f);
        _isFlyOver = true;
    }

    IEnumerator MoveCube(GameObject cube, Vector3 target, float _speed)
    {
        while (cube.transform.position != target)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, _speed * Time.deltaTime);
            yield return null;
        }


        // StartCoroutine(Move());
    }


    void Update()
    {
        if (_isFlyOver)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    if (cubeGrid[i, j] != null)
                    {
                        float waveOffset = Mathf.Sin((Time.time + (i + j)) * waveSpeed) * waveHeight;
                        Vector3 newPosition = cubeGrid[i, j].transform.position + new Vector3(0, 0, waveOffset);
                        cubeGrid[i, j].transform.position = newPosition;
                    }
                }
            }
        }


        if (Input.GetKeyDown(flyBackKey))
        {
            FlyBackAllCubes();
            Debug.Log(cubeList.Count);
        }
    }


    public void FlyBackAllCubes()
    {
        Debug.Log("FlyBackAllCubes");
        
        for (int i = 0; i < cubeList.Count; i++)
        {
            if (cubeList[i] != null)
            {
                float flySpeed = UnityEngine.Random.Range(1, 5);
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
        
        cubeList.Remove(cube);
        cube.gameObject.SetActive(false);
    }
}
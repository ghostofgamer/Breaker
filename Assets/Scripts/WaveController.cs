using System.Collections;
using System.Collections.Generic;
using Bricks;
using ObjectPoolFiles;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int columns;
    public int rows;
    public float waveSpeed;
    public float waveAmplitude;
    public int waveCount;
    public float waitBetweenWaves;

    private List<Vector3> initialCubePositions;
    private List<Brick> brickList;
    private float waveTimer;
    private int currentWave;
    private ObjectPool<Brick> _pool;
    private bool _autoExpand = true;
    [SerializeField] private Transform _container;
    [SerializeField] private Brick _cube;
    private void Awake()
    {
        _pool = new ObjectPool<Brick>(_cube, columns * rows, _container);
        _pool.SetAutoExpand(_autoExpand);
    }
    
    void Start()
    {
        brickList = new List<Brick>();

        // Собираем все кубы в контейнере
        foreach (Transform child in transform)
        {
            Brick brick = child.GetComponent<Brick>();
            
            if (brick != null)
            {
                brickList.Add(brick);
            }
        }

        // Сохраняем начальные позиции кубов
        initialCubePositions = new List<Vector3>();
        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                initialCubePositions.Add(brickList[i * rows + j].transform.localPosition);
            }
        }

        currentWave = 0;
        waveTimer = 0;
        StartCoroutine(StartWaves());
    }

    void Update()
    {
        waveTimer += Time.deltaTime;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                int index = i * rows + j;
                Vector3 position = initialCubePositions[index];
                position.z += Mathf.Sin(waveTimer + (i * waitBetweenWaves)) * waveAmplitude;
                brickList[index].transform.localPosition = position;
            }
        }
    }

    private IEnumerator StartWaves()
    {
        while (currentWave < waveCount)
        {
            currentWave++;
            yield return new WaitForSeconds(waitBetweenWaves * columns);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaveMotion : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;
    [SerializeField] private float _waveSpeed;
    [SerializeField] private float _waveHeight;
    [SerializeField] private float _cubeSpacing;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private KeyCode _flyBackKey = KeyCode.Space;
    [SerializeField] private float _minFlySpeed;
    [SerializeField] private float _maxFlySpeed;
    [SerializeField] private int _columns;
    [SerializeField] private int _rows;

    private GameObject[,] _cubeGrid;
    private List<GameObject> _cubeList;
    private GameObject[,] _cubes;
    private Vector3[,] _startPositions;
    private Vector3[,] _endPositions;
    private float _time;
    private bool _isFlyOver = false;

    void Start()
    {
        _cubeList = new List<GameObject>();
        _cubeGrid = new GameObject[_columns, _rows];

        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Vector3 position = _startPosition - new Vector3(i * _cubeSpacing, j * _cubeSpacing, 0);
                GameObject cube = Instantiate(_cubePrefab, position, Quaternion.identity);
                _cubeGrid[i, j] = cube;
                _cubeList.Add(cube);
            }
        }

        StartCoroutine(MoveCubes());
    }

    IEnumerator MoveCubes()
    {
        for (int i = 0; i < _columns; i++)
        {
            for (int j = 0; j < _rows; j++)
            {
                Vector3 startPosition = _cubeGrid[i, j].transform.position;
                Vector3 endPosition = startPosition - new Vector3(0, 0, 15);
                float speed = Random.Range(_minFlySpeed, _maxFlySpeed);
                StartCoroutine(MoveCube(_cubeGrid[i, j], endPosition, speed));
            }

            yield return null;
        }

        yield return new WaitForSeconds(0.3f);
        _isFlyOver = true;
    }

    IEnumerator MoveCube(GameObject cube, Vector3 target, float speed)
    {
        while (cube.transform.position != target)
        {
            cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
    }

    void Update()
    {
        if (_isFlyOver)
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    if (_cubeGrid[i, j] != null)
                    {
                        float waveOffset = Mathf.Sin((Time.time + (i + j)) * _waveSpeed) * _waveHeight;
                        Vector3 newPosition = _cubeGrid[i, j].transform.position + new Vector3(0, 0, waveOffset);
                        _cubeGrid[i, j].transform.position = newPosition;
                    }
                }
            }
        }

        if (Input.GetKeyDown(_flyBackKey))
        {
            FlyBackAllCubes();
            Debug.Log(_cubeList.Count);
        }
    }

    public void FlyBackAllCubes()
    {
        foreach (GameObject cube in _cubeList)
        {
            if (cube != null)
            {
                float flySpeed = UnityEngine.Random.Range(1, 5);
                StartCoroutine(FlyBackCube(cube, flySpeed));
            }
        }
    }

    IEnumerator FlyBackCube(GameObject cube, float speed)
    {
        Vector3 startPosition = cube.transform.position;
        Vector3 endPosition = startPosition - new Vector3(0, 0, -10);
        float flyTime = 1.0f / speed;
        float elapsedTime = 0;

        while (elapsedTime < flyTime)
        {
            cube.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / flyTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _cubeList.Remove(cube);
        cube.gameObject.SetActive(false);
    }
}
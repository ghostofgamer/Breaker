using System.Collections;
using System.Collections.Generic;
using Bricks;
using ObjectPoolFiles;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainMenu
{
    public class WaveMotion : MonoBehaviour
    {
        [SerializeField] private Brick _cube;
        [SerializeField] private float _waveSpeed;
        [SerializeField] private float _waveHeight;
        [SerializeField] private float _cubeSpacing;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private KeyCode _flyBackKey = KeyCode.Space;
        [SerializeField] private float _minFlySpeed;
        [SerializeField] private float _maxFlySpeed;
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private Transform _container;
        [SerializeField] private Material[] _materials;

        private Brick[,] _brickGrid;
        private List<Brick> _brickList;
        private GameObject[,] _cubes;
        private Vector3[,] _startPositions;
        private Vector3[,] _endPositions;
        private float _time;
        private bool _isFlyOver = false;
        private ObjectPool<Brick> _pool;
        private bool _autoExpand = true;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private float _distanceStartFly = 15f;
        private float _distanceEndFly = 10f;
        private int _minValue = 1;
        private int _maxValue = 5;
        private float _factor = 1f;


        public int waveCount; // Количество волн
        private int currentWave; // Текущая волна
        private List<Vector3> initialCubePositions;
        [SerializeField] private float _waitBetweenWaves = 0.1f;
        [SerializeField] private float waveTimer;
        public float waveAmplitude;
        [SerializeField] private float _amplitudeDuration  = 3f;

        private void Awake()
        {
            _pool = new ObjectPool<Brick>(_cube, _columns * _rows, _container);
            _pool.SetAutoExpand(_autoExpand);
        }

        private void Start()
        {
            // Создаем и позиционируем кубы
            _brickList = new List<Brick>();
            _brickGrid = new Brick[_columns, _rows];

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 position = _startPosition - new Vector3(i * _cubeSpacing, j * _cubeSpacing, 0);
                    _pool.GetFirstObject(out Brick brick, _cube);

                    brick.transform.position = position;
                    brick.gameObject.SetActive(true);
                    MeshRenderer meshRederer = brick.GetComponent<MeshRenderer>();
                    meshRederer.enabled = false;
                    meshRederer.material = _materials[Random.Range(0, _materials.Length)];

                    _brickGrid[i, j] = brick;
                    _brickList.Add(brick);
                }
            }

            // Сохраняем начальные позиции кубов
            /*initialCubePositions = new List<Vector3>();
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 relativePosition = _brickGrid[i, j].transform.position - _container.transform.position;
                    initialCubePositions.Add(relativePosition);
                }
            }*/

            currentWave = 0;
            StartCoroutine(MoveCubes());
        }

        /*private void Start()
        {
            _brickList = new List<Brick>();
            _brickGrid = new Brick[_columns, _rows];

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 position = _startPosition - new Vector3(i * _cubeSpacing, j * _cubeSpacing, 0);
                    _pool.GetFirstObject(out Brick brick, _cube);
                    /*Brick currentBrick = brick;
                    currentBrick.transform.position = position;
                    currentBrick.gameObject.SetActive(true);
                    currentBrick.GetComponent<MeshRenderer>().enabled = false;#1#
                    brick.transform.position = position;
                    brick.gameObject.SetActive(true);
                    MeshRenderer meshRederer = brick.GetComponent<MeshRenderer>();
                    meshRederer.enabled = false;
                    meshRederer.material = _materials[Random.Range(0, _materials.Length)];
                    // brick.GetComponent<MeshRenderer>().enabled = false;
                    _brickGrid[i, j] = brick;
                    _brickList.Add(brick);
                }
            }

            StartCoroutine(MoveCubes());
        }*/

        /*private void Update()
        {
            if (_isFlyOver)
            {
                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        if (_brickGrid[i, j] != null)
                        {
                            float waveOffset = Mathf.Sin((Time.time + (i + j)) * _waveSpeed * Time.timeScale) *
                                               _waveHeight;

                            int index = i * _rows + j;
                            Vector3 targetRelativePosition = initialCubePositions[index];
                            targetRelativePosition.z += waveOffset;

                            // Преобразуем относительную позицию в глобальную позицию
                            Vector3 targetPosition = _container.transform.position + targetRelativePosition;

                            // Сглаживание движения кубов с помощью линейной интерполяции (Lerp)
                            float smoothFactor = 10f * Time.deltaTime;
                            _brickGrid[i, j].transform.position = Vector3.Lerp(_brickGrid[i, j].transform.position, targetPosition, smoothFactor);
                        }
                    }
                }
            }
        }*/
        
        
        /*private void Update()
        {
            if (_isFlyOver)
            {
                waveTimer += Time.deltaTime;

                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        if (_brickGrid[i, j] != null)
                        {
                            float waveOffset = Mathf.Sin((Time.time + (i + j)) * _waveSpeed * Time.timeScale) *
                                               _waveHeight;

                            int index = i * _rows + j;
                            Vector3 targetPosition = initialCubePositions[index];
                            targetPosition.z += waveOffset;

                            // Сглаживание движения кубов с помощью линейной интерполяции (Lerp)
                            float smoothFactor = 10f * Time.deltaTime;
                            _brickGrid[i, j].transform.localPosition = Vector3.Lerp(_brickGrid[i, j].transform.localPosition, targetPosition, smoothFactor);
                        }
                    }
                }
            }
        }*/
        private void Update()
        {
            if (_isFlyOver)
            {
                waveTimer += Time.deltaTime;

                // Вычисляем циклическое значение амплитуды волны
                float amplitudeT = Mathf.PingPong(waveTimer / _amplitudeDuration, 1);
                float waveAmplitude = Mathf.Lerp(0.1f, 6, amplitudeT);
Debug.Log(waveAmplitude);
                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        int index = i * _rows + j;
                        Vector3 position = initialCubePositions[index];
                        position.z += Mathf.Sin(waveTimer + (i * _waitBetweenWaves)) * waveAmplitude;
                        _brickList[index].transform.localPosition = position;
                    }
                }
            }
        }
        /*void Update()
        {
            if (_isFlyOver)
            {
                waveTimer += Time.deltaTime;

                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        int index = i * _rows + j;
                        Vector3 position = initialCubePositions[index];
                        position.z += Mathf.Sin(waveTimer + (i * _waitBetweenWaves)) * waveAmplitude;
                        _brickList[index].transform.localPosition = position;
                    }
                }
            }
        }*/
        
     
        /*private void Update()
        {
            if (_isFlyOver)
            {
                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        if (_brickGrid[i, j] != null)
                        {
                            float waveOffset = Mathf.Sin((Time.time + (i + j)) * _waveSpeed * Time.timeScale) *
                                               _waveHeight;
                            Vector3 newPosition = _brickGrid[i, j].transform.position + new Vector3(0, 0, waveOffset);
                            _brickGrid[i, j].transform.position = newPosition;
                        }
                    }
                }
            }

            if (Input.GetKeyDown(_flyBackKey))
            {
                FlyBackAllCubes();
            }
        }*/

        public void FlyBackAllCubes()
        {
            foreach (Brick cube in _brickList)
            {
                if (cube != null)
                {
                    float flySpeed = Random.Range(_minValue, _maxValue);
                    StartCoroutine(FlyBackCube(cube, flySpeed));
                }
            }
        }

        private IEnumerator MoveCubes()
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 startPosition = _brickGrid[i, j].transform.position;
                    Vector3 endPosition = startPosition - new Vector3(0, 0, _distanceStartFly);
                    float speed = Random.Range(_minFlySpeed, _maxFlySpeed);
                    // var msw  = _brickGrid[i, j].GetComponent<MeshRenderer>().enabled = true;
                    StartCoroutine(MoveCube(_brickGrid[i, j], endPosition, speed));
                }

                yield return null;
            }
            
            initialCubePositions = new List<Vector3>();

            // yield return _waitForSeconds;
            yield return new WaitForSeconds(0.6f);
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 relativePosition = _brickGrid[i, j].transform.position - _container.transform.position;
                    initialCubePositions.Add(relativePosition);
                }
            }

            _isFlyOver = true;
        }

        private IEnumerator MoveCube(Brick cube, Vector3 target, float speed)
        {
            while (cube.transform.position != target)
            {
                cube.GetComponent<MeshRenderer>().enabled = true;
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator FlyBackCube(Brick cube, float speed)
        {
            Vector3 startPosition = cube.transform.position;
            Vector3 endPosition = startPosition - new Vector3(0, 0, -_distanceEndFly);
            float flyTime = _factor / speed;
            float elapsedTime = 0;

            while (elapsedTime < flyTime)
            {
                cube.transform.position = Vector3.Lerp(startPosition, endPosition, (elapsedTime / flyTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _brickList.Remove(cube);
            cube.gameObject.SetActive(false);
        }
    }
}
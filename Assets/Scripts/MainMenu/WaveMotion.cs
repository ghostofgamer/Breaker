using System.Collections;
using System.Collections.Generic;
using Bricks;
using ObjectPoolFiles;
using Others;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainMenu
{
    public class WaveMotion : MonoBehaviour
    {
        [SerializeField] private Brick _cube;
        [SerializeField] private float _cubeSpacing;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _minFlySpeed;
        [SerializeField] private float _maxFlySpeed;
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private Transform _container;
        [SerializeField] private Material[] _materials;
        [SerializeField] private AnimationsController _animationsController;
        [SerializeField] private float _waitBetweenWaves = 0.1f;
        [SerializeField] private float _amplitudeDuration = 3f;

        private float _waveTimer = 0;
        private Brick[,] _brickGrid;
        private List<Brick> _brickList;
        private GameObject[,] _cubes;
        private Vector3[,] _startPositions;
        private Vector3[,] _endPositions;
        private float _time;
        private bool _isFlyOver = false;
        private ObjectPool<Brick> _pool;
        private bool _autoExpand = true;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.6f);
        private float _distanceStartFly = 15f;
        private float _distanceEndFly = 10f;
        private int _minValue = 1;
        private int _maxValue = 5;
        private float _factor = 1f;
        private float _minAmplitude = 0.1f;
        private float _maxAmplitude = 5f;
        private List<Vector3> _initialCubePositions;
        private float _flySpeed;
        private float _waveAmplitude;

        private void Awake()
        {
            _pool = new ObjectPool<Brick>(_cube, _columns * _rows, _container);
            _pool.SetAutoExpand(_autoExpand);
        }

        private void Start()
        {
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

            StartCoroutine(MoveCubes());
        }

        private void Update()
        {
            if (_isFlyOver)
            {
                _waveTimer += Time.deltaTime;
                float amplitudeT = Mathf.PingPong(_waveTimer / _amplitudeDuration, _factor);
                _waveAmplitude = Mathf.Lerp(_minAmplitude, _maxAmplitude, amplitudeT);

                for (int i = 0; i < _columns; i++)
                {
                    for (int j = 0; j < _rows; j++)
                    {
                        int index = (i * _rows) + j;
                        Vector3 position = _initialCubePositions[index];
                        position.z += Mathf.Sin(_waveTimer + (i * _waitBetweenWaves)) * _waveAmplitude;
                        _brickList[index].transform.localPosition = position;
                    }
                }
            }
        }

        public void FlyBackAllCubes()
        {
            foreach (Brick cube in _brickList)
            {
                if (cube != null)
                {
                    _flySpeed = Random.Range(_minValue, _maxValue);
                    StartCoroutine(FlyBackCube(cube, _flySpeed));
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
                    StartCoroutine(MoveCube(_brickGrid[i, j], endPosition, speed));
                }

                yield return null;
            }

            _initialCubePositions = new List<Vector3>();
            yield return _waitForSeconds;

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 relativePosition = _brickGrid[i, j].transform.position - _container.transform.position;
                    _initialCubePositions.Add(relativePosition);
                }
            }

            _animationsController.PlayWave();
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
                cube.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / flyTime);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            _brickList.Remove(cube);
            cube.gameObject.SetActive(false);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using Bricks;
using Others;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MainMenu
{
    public class WaveMotion : MonoBehaviour
    {
        [SerializeField] private float _minFlySpeed;
        [SerializeField] private float _maxFlySpeed;
        [SerializeField] private Transform _container;
        [SerializeField] private AnimationsActivator _animationsActivator;
        [SerializeField] private float _waitBetweenWaves = 0.1f;
        [SerializeField] private float _amplitudeDuration = 3f;

        private int _columns;
        private int _rows;
        private float _waveTimer = 0;
        private List<BrickCoordinator> _brickList;
        private bool _isFlyOver = false;
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

        public void Init(List<BrickCoordinator> brickList, int columns, int rows)
        {
            _brickList = new List<BrickCoordinator>();
            _brickList = brickList;
            _columns = columns;
            _rows = rows;
        }

        public void MoveActivation(BrickCoordinator[,] brickGrid)
        {
            StartCoroutine(MoveCubes(brickGrid));
        }

        public void FlyBackAllCubes()
        {
            foreach (BrickCoordinator cube in _brickList)
            {
                if (cube != null)
                {
                    _flySpeed = Random.Range(_minValue, _maxValue);
                    StartCoroutine(FlyBackCube(cube, _flySpeed));
                }
            }
        }

        private IEnumerator MoveCubes(BrickCoordinator[,] brickGrid)
        {
            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 startPosition = brickGrid[i, j].transform.position;
                    Vector3 endPosition = startPosition - new Vector3(0, 0, _distanceStartFly);
                    float speed = Random.Range(_minFlySpeed, _maxFlySpeed);
                    StartCoroutine(MoveCube(brickGrid[i, j], endPosition, speed));
                }

                yield return null;
            }

            _initialCubePositions = new List<Vector3>();
            yield return _waitForSeconds;

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 relativePosition = brickGrid[i, j].transform.position - _container.transform.position;
                    _initialCubePositions.Add(relativePosition);
                }
            }

            _animationsActivator.PlayWave();
            _isFlyOver = true;
        }

        private IEnumerator MoveCube(BrickCoordinator cube, Vector3 target, float speed)
        {
            while (cube.transform.position != target)
            {
                cube.GetComponent<MeshRenderer>().enabled = true;
                cube.transform.position = Vector3.MoveTowards(cube.transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
        }

        private IEnumerator FlyBackCube(BrickCoordinator cube, float speed)
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
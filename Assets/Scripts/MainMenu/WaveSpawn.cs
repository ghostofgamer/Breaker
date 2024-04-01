using System.Collections.Generic;
using Bricks;
using ObjectPoolFiles;
using UnityEngine;

namespace MainMenu
{
    public class WaveSpawn : MonoBehaviour
    {
        [SerializeField] private BrickCoordinator _cube;
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private Transform _container;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _cubeSpacing;
        [SerializeField] private Material[] _materials;
        [SerializeField]private WaveMotion _waveMotion;

        private ObjectPool<BrickCoordinator> _pool;
        private BrickCoordinator[,] _brickGrid;
        private List<BrickCoordinator> _brickList;

        private void Awake()
        {
            _pool = new ObjectPool<BrickCoordinator>(_cube, _columns * _rows, _container);
            _pool.EnableAutoExpand();
        }

        private void Start()
        {
            _brickList = new List<BrickCoordinator>();
            _brickGrid = new BrickCoordinator[_columns, _rows];

            for (int i = 0; i < _columns; i++)
            {
                for (int j = 0; j < _rows; j++)
                {
                    Vector3 position = _startPosition - new Vector3(i * _cubeSpacing, j * _cubeSpacing, 0);
                    BrickCoordinator brickCoordinator = _pool.GetFirstObject();
                    brickCoordinator.transform.position = position;
                    brickCoordinator.gameObject.SetActive(true);
                    MeshRenderer meshRederer = brickCoordinator.GetComponent<MeshRenderer>();
                    meshRederer.enabled = false;
                    meshRederer.material = _materials[Random.Range(0, _materials.Length)];
                    _brickGrid[i, j] = brickCoordinator;
                    _brickList.Add(brickCoordinator);
                }
            }

            _waveMotion.Init(_brickList, _columns, _rows);
            _waveMotion.MoveActivation(_brickGrid);
        }
    }
}
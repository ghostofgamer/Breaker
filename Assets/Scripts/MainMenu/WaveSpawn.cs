using System.Collections.Generic;
using Bricks;
using ObjectPoolFiles;
using UnityEngine;

namespace MainMenu
{
    public class WaveSpawn : MonoBehaviour
    {
        [SerializeField] private Brick _cube;
        [SerializeField] private int _columns;
        [SerializeField] private int _rows;
        [SerializeField] private Transform _container;
        [SerializeField] private Vector3 _startPosition;
        [SerializeField] private float _cubeSpacing;
        [SerializeField] private Material[] _materials;
        [SerializeField]private WaveMotion _waveMotion;

        private ObjectPool<Brick> _pool;
        private Brick[,] _brickGrid;
        private List<Brick> _brickList;

        private void Awake()
        {
            _pool = new ObjectPool<Brick>(_cube, _columns * _rows, _container);
            _pool.EnableAutoExpand();
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
                    Brick brick = _pool.GetFirstObject();
                    brick.transform.position = position;
                    brick.gameObject.SetActive(true);
                    MeshRenderer meshRederer = brick.GetComponent<MeshRenderer>();
                    meshRederer.enabled = false;
                    meshRederer.material = _materials[Random.Range(0, _materials.Length)];
                    _brickGrid[i, j] = brick;
                    _brickList.Add(brick);
                }
            }

            _waveMotion.Init(_brickList, _columns, _rows);
            _waveMotion.MoveActivation(_brickGrid);
        }
    }
}
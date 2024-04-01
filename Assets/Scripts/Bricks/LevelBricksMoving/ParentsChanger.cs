using System.Collections.Generic;
using Statistics;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class ParentsChanger : MonoBehaviour
    {
        [SerializeField] private Transform _parentTarget;
        [SerializeField] private Transform _environment;
        [SerializeField] private BrickCoordinator[] _bricks;
        [SerializeField] private BrickCoordinator[] _bricksEternal;
        [SerializeField] private BrickCoordinator _brickCoordinator;
        [SerializeField] private BrickCounter _brickCounter;

        private List<Rigidbody> _rigidbodies;

        private void OnEnable()
        {
            if (_brickCoordinator != null)
                _brickCoordinator.Dead += ChangeParent;

            if (_brickCounter != null)
                _brickCounter.AllBrickDestroyed += OnSetParentEnviropment;
        }

        private void OnDisable()
        {
            if (_brickCoordinator != null)
                _brickCoordinator.Dead -= ChangeParent;

            if (_brickCounter != null)
                _brickCounter.AllBrickDestroyed += OnSetParentEnviropment;
        }

        private void Start()
        {
            _rigidbodies = new List<Rigidbody>();

            foreach (BrickCoordinator brick in _bricks)
                _rigidbodies.Add(brick.GetComponent<Rigidbody>());
        }

        private void ChangeParent()
        {
            foreach (Rigidbody rigidbodyValue in _rigidbodies)
            {
                rigidbodyValue.isKinematic = false;
                rigidbodyValue.transform.parent = _parentTarget;
            }
        }

        private void OnSetParentEnviropment()
        {
            if (_bricksEternal.Length <= 0)
                return;

            foreach (var brick in _bricksEternal)
                brick.transform.parent = _environment;
        }
    }
}
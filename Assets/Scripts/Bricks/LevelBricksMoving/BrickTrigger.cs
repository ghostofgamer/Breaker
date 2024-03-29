using System.Collections.Generic;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class BrickTrigger : MonoBehaviour
    {
        [SerializeField] private Brick[] _bricks;
        [SerializeField] private Brick[] _bricksTrigger;

        private List<Rigidbody> _rigidbodys;

        private void OnEnable()
        {
            foreach (var brick in _bricksTrigger)
                brick.Dead += OnShutdown;
        }

        private void OnDisable()
        {
            foreach (var brick in _bricksTrigger)
                brick.Dead -= OnShutdown;
        }

        protected virtual void Start()
        {
            _rigidbodys = new List<Rigidbody>();

            foreach (Brick brick in _bricks)
                _rigidbodys.Add(brick.GetComponent<Rigidbody>());
        }

        protected virtual void OnShutdown()
        {
            DisableKinematic();
            enabled = false;
        }

        protected void GiveImpulse(Vector3 direction, float minValue, float maxValue)
        {
            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
                brick.GetComponent<Rigidbody>().AddForce(-direction.normalized * Random.Range(minValue, maxValue), ForceMode.Impulse);
            }
        }

        private void DisableKinematic()
        {
            foreach (Rigidbody rigidbodyValue in _rigidbodys)
                rigidbodyValue.isKinematic = false;
        }
    }
}
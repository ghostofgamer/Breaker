using System.Collections.Generic;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class BrickTriggerController : MonoBehaviour
    {
        [SerializeField] private Brick[] _bricks;
        [SerializeField] private Brick[] _bricksTrigger;

        private List<Rigidbody> _rigidbodys;

        private void OnEnable()
        {
            foreach (var brick in _bricksTrigger)
                brick.Dead += SetValue;
        }

        private void OnDisable()
        {
            foreach (var brick in _bricksTrigger)
                brick.Dead -= SetValue;
        }

        protected virtual void Start()
        {
            _rigidbodys = new List<Rigidbody>();

            foreach (Brick brick in _bricks)
                _rigidbodys.Add(brick.GetComponent<Rigidbody>());
        }

        protected virtual void SetValue()
        {
            foreach (Rigidbody rigidbodyValue in _rigidbodys)
                rigidbodyValue.isKinematic = false;

            enabled = false;
        }

        protected void GiveImpulse(Vector3 direction, float minValue, float maxValue)
        {
            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = false;
                brick.GetComponent<Rigidbody>().AddForce(-direction.normalized * Random.Range(minValue, maxValue),
                    ForceMode.Impulse);
            }
        }
    }
}
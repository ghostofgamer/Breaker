using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level6
{
    public class LoopedMovement : BrickTriggerController
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _delay;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _start;

        private Vector3 _targetPosition;
        private Vector3 _startPosition;
        private Rigidbody _rigidbody;
        private Coroutine _coroutine;
        private bool _isWork = true;
        
        protected override void Start()
        {
            base.Start();
            _coroutine =   StartCoroutine(MoveCycle());
        }
        
        /*
        private void OnEnable()
        {
            foreach (var brick in _bricks)
            {
                brick.Dead += SetValue;
            }
        }

        private void OnDisable()
        {
            foreach (var brick in _bricks)
            {
                brick.Dead -= SetValue;
            }
        }*/

        private IEnumerator MoveCycle()
        {
            while (_isWork)
            {
                yield return MoveToPosition(_target.position);
                yield return new WaitForSeconds(_delay);
                yield return MoveToPosition(_start.position);
                yield return new WaitForSeconds(_delay);
            }
        }

        private IEnumerator MoveToPosition(Vector3 destination)
        {
            while (transform.position != destination)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, _speed * Time.deltaTime);
                yield return null;
            }
        }

        protected override void SetValue()
        {
            base.SetValue();
            _isWork = false;
            StopCoroutine(_coroutine);
        }

        /*
        private void SetValue()
        {
            _rigidbody.isKinematic = false;
            StopCoroutine(_coroutine);
            enabled = false;
        }*/
    }
}
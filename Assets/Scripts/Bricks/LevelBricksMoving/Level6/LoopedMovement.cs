using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level6
{
    public class LoopedMovement : BrickTrigger
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _delay;
        [SerializeField] private Transform _target;
        [SerializeField] private Transform _start;

        private Coroutine _coroutine;
        private bool _isWork = true;
        private WaitForSeconds _waitForSeconds;

        protected override void Start()
        {
            base.Start();
            _waitForSeconds = new WaitForSeconds(_delay);
            _coroutine = StartCoroutine(MoveCycle());
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
            _isWork = false;
            StopCoroutine(_coroutine);
        }

        private IEnumerator MoveCycle()
        {
            while (_isWork)
            {
                yield return MoveToPosition(_target.position);
                yield return _waitForSeconds;
                yield return MoveToPosition(_start.position);
                yield return _waitForSeconds;
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
    }
}
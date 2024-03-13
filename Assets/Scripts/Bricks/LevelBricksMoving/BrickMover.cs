using System.Collections;
using UnityEngine;

namespace Bricks.LevelBricksMoving
{
    public class BrickMover : MonoBehaviour
    {
        [SerializeField] private float _moveDistance;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _duration;
        [SerializeField] private Brick[] _bricks;

        private Vector3 _initialPosition;
        private Vector3 _targetPosition;
        private bool _isPaused = false;
        private bool _isTargetPosition = false;
        private WaitForSeconds _waitForSeconds;
        private Coroutine _coroutine;

        void Start()
        {
            _initialPosition = transform.position;
            _waitForSeconds = new WaitForSeconds(_duration);
            _targetPosition = new Vector3(_initialPosition.x + _moveDistance, _initialPosition.y, _initialPosition.z);

            foreach (var brick in _bricks)
            {
                brick.GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        void Update()
        {
            if (!_isPaused)
                BricksMove();

            if (_bricks[0].gameObject.activeSelf == false)
                Over();
        }

        private void Over()
        {
            foreach (var brick in _bricks)
                brick.GetComponent<Rigidbody>().isKinematic = false;

            this.enabled = false;
        }

        private void BricksMove()
        {
            if (!_isTargetPosition)
                MoveDirection(_targetPosition, true);
            else
                MoveDirection(_initialPosition, false);
        }

        private void MoveDirection(Vector3 targetPosition, bool isTargetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, _moveSpeed * Time.deltaTime);

            foreach (Brick brick in _bricks)
            {
                brick.transform.position = new Vector3(transform.position.x, brick.transform.position.y,
                    brick.transform.position.z);
            }

            if (transform.position == targetPosition)
            {
                _isTargetPosition = isTargetPosition;
                ActivatedPause();
            }
        }

        private void ActivatedPause()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(SetPause());
        }

        private IEnumerator SetPause()
        {
            _isPaused = true;
            yield return _waitForSeconds;
            _isPaused = false;
        }
    }
}
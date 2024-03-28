using UnityEngine;

namespace Bricks.LevelBricksMoving.Level7
{
    public class MovingStairs : BrickTriggerController
    {
        [SerializeField] private Transform _targetA;
        [SerializeField] private Transform _targetB;
        [SerializeField] private float _moveDuration = 1f;

        private Vector3 _startPosition;
        private bool _isMovingToTargetA = true;
        private float _moveTimer;

        protected override void Start()
        {
            base.Start();
            _startPosition = transform.position;
        }

        private void Update()
        {
            if (_moveTimer < _moveDuration)
            {
                _moveTimer += Time.deltaTime;
                float t = _moveTimer / _moveDuration;
                Vector3 targetPosition = _isMovingToTargetA ? _targetA.position : _targetB.position;
                transform.position = Vector3.Lerp(_startPosition, targetPosition, t);
            }
            else
            {
                _moveTimer = 0f;
                _isMovingToTargetA = !_isMovingToTargetA;
                _startPosition = transform.position;
            }
        }
    }
}
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level10
{
    public class TriangleMovement : WorkChanger
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private BaseMovement _baseMovement;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _moveStep;

        private Vector3 _position;
        private float _targetX;

        private void Update()
        {
            if (IsWork)
            {
                _position = transform.position;
                _targetX = _position.x + (_baseMovement.DirectionX * _movementSpeed * Time.deltaTime);
                _targetX = Mathf.Clamp(_targetX, _minX, _maxX);

                _position = Vector3.MoveTowards(
                    _position, 
                    new Vector3(_targetX, _position.y, _position.z), 
                    _moveStep * Time.deltaTime);
                transform.position = _position;
            }
        }
    }
}
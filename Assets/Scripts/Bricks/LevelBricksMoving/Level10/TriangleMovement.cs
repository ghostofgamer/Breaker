using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace Bricks.LevelBricksMoving.Level10
{
    public class TriangleMovement : MotionController
    {
        [SerializeField] private float _movementSpeed;
        [SerializeField] private PlatformaMover _platformaMover;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _moveStep;

        private void Update()
        {
            if (IsWork)
            {
                Vector3 position = transform.position;
                float targetX = position.x + (_platformaMover.DirectionX * _movementSpeed * Time.deltaTime);
                targetX = Mathf.Clamp(targetX, _minX, _maxX);

                position = Vector3.MoveTowards(position,
                    new Vector3(targetX, position.y, position.z), _moveStep * Time.deltaTime);
                transform.position = position;
            }
        }
    }
}
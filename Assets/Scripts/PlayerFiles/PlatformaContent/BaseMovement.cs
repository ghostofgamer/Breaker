using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class BaseMovement : BaseLife
    {
        [SerializeField] private GameObject _positionMouse;

        private float _moveSpeed = 50f;
        private float _offset = 3f;
        private float _minX = -11f;
        private float _maxX = 11f;
        private float _minZ = -10f;
        private float _maxZ = 5f;
        private int _directionX = 1;
        private bool _isReverse = false;

        public float Speed => _moveSpeed;

        public int DirectionX { get; private set; }

        public void SetValue(float speed)
        {
            _moveSpeed = speed;
        }

        public void EnableReverse()
        {
            _isReverse = true;
        }

        public void DisableReverse()
        {
            _isReverse = false;
        }

        public void MovePlatformWithMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition;

                if (_isReverse)
                    targetPosition = new Vector3(-hit.point.x, transform.position.y, -(hit.point.z + _offset));
                else
                    targetPosition = new Vector3(hit.point.x, transform.position.y, hit.point.z + _offset);

                float clampedX = Mathf.Clamp(targetPosition.x, _minX, _maxX);
                float clampedZ = Mathf.Clamp(targetPosition.z, _minZ, _maxZ);
                SetDirection(clampedX);
                Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);
                Vector3 targetPositiomMouse = new Vector3(hit.point.x, 4, hit.point.z);
                _positionMouse.transform.position = targetPositiomMouse;
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    clampedTargetPosition,
                    _moveSpeed * Time.deltaTime);
            }
        }

        private void SetDirection(float x)
        {
            if (x > transform.position.x)
                DirectionX = _directionX;
            else if (x < transform.position.x)
                DirectionX = -_directionX;
            else
                DirectionX = 0;
        }
    }
}
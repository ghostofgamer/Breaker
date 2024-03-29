using System.Collections;
using GameScene.BallContent;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class PlatformaMover : MonoBehaviour
    {
        [SerializeField] private GameObject _positionMouse;
        [SerializeField] private Ball _ball;

        private float _moveSpeed = 50f;
        private float _offset = 3f;
        private float _minX = -11f;
        private float _maxX = 11f;
        private float _minZ = -10f;
        private float _maxZ = 5f;
        private float _slowMove = 0.35f;
        private float _factor = 2f;
        private int _directionX = 1;
        private bool _isMousePressed = false;
        private bool _isReverse = false;
        private bool _isFirstThrow = true;
        private Vector2 _mouseDirection;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private Coroutine _coroutine;
        private string _mouseX = "Mouse X";

        public bool IsAlive { get; private set; }

        public float Speed => _moveSpeed;

        public int DirectionX { get; private set; }

        private void Update()
        {
            float mouse = Input.GetAxis(_mouseX) * _factor;

            if (Input.GetMouseButtonDown(0))
            {
                _positionMouse.SetActive(true);
                _isMousePressed = true;
                Time.timeScale = 1;
            }

            if (Input.GetMouseButtonUp(0))
            {
                if (!_ball.IsMoving)
                    _ball.SetMove(true, mouse);

                _positionMouse.SetActive(false);
                _isMousePressed = false;

                if (_coroutine != null)
                    StopCoroutine(_coroutine);

                if (!_isFirstThrow)
                    StartCoroutine(TimeScaleChanged());

                if (_isFirstThrow)
                    _isFirstThrow = false;
            }

            if (_isMousePressed)
            {
                MovePlatformWithMouse();
            }
        }

        public void SetValue(float speed)
        {
            _moveSpeed = speed;
        }

        public void SetReverse(bool reverse)
        {
            _isReverse = reverse;
        }

        public void SetPressed(bool flag)
        {
            _isMousePressed = flag;
        }

        public void Revive()
        {
            _isMousePressed = false;
            _isFirstThrow = true;
            gameObject.SetActive(true);
            SetValue(true);
        }

        public void SetValue(bool flag)
        {
            IsAlive = flag;
        }

        private void GetDirection(float x)
        {
            if (x > transform.position.x)
                DirectionX = _directionX;
            else if (x < transform.position.x)
                DirectionX = -_directionX;
            else
                DirectionX = 0;
        }

        private IEnumerator TimeScaleChanged()
        {
            Time.timeScale = _slowMove;
            yield return _waitForSeconds;

            while (Time.timeScale < 1f)
                Time.timeScale += Time.deltaTime;
        }

        private void MovePlatformWithMouse()
        {
            Vector3 mouseScreenPosition = Input.mousePosition;
            mouseScreenPosition.z = Camera.main.nearClipPlane;
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
                GetDirection(clampedX);
                Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);
                Vector3 targetPositiomMouse = new Vector3(hit.point.x, 4, hit.point.z);
                _positionMouse.transform.position = targetPositiomMouse;
                transform.position =
                    Vector3.MoveTowards(transform.position, clampedTargetPosition, _moveSpeed * Time.deltaTime);
            }
        }
    }
}
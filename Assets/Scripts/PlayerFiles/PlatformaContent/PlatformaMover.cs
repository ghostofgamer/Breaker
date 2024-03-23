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
        private bool _isMousePressed = false;
        private bool _isReverse = false;
        private bool _isFirstThrow = true;
        private Vector2 _mouseDirection;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.3f);
        private Coroutine _coroutine;
        private string _mouseX = "Mouse X";

        public float Speed => _moveSpeed;

        public int DirectionX { get; private set; }

        void Update()
        {
            float mouse = Input.GetAxis(_mouseX) * 2;

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

        private IEnumerator TimeScaleChanged()
        {
            Time.timeScale = 0.35f;
            yield return _waitForSeconds;

            while (Time.timeScale < 1f)
                Time.timeScale += Time.deltaTime;
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

        void MovePlatformWithMouse()
        {
            // Определяем целевую позицию в мировых координатах с учетом оффсета
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
                GetDirection(targetPosition, clampedX);

                Vector3 clampedTargetPosition = new Vector3(clampedX, targetPosition.y, clampedZ);
                Vector3 targetPositiomMouse = new Vector3(hit.point.x, 4, hit.point.z);

                _positionMouse.transform.position = targetPositiomMouse;
                // _positionMouse.transform.position = hit.point;
                transform.position =
                    Vector3.MoveTowards(transform.position, clampedTargetPosition, _moveSpeed * Time.deltaTime);
            }
        }

        public void Revive()
        {
            _isMousePressed = false;
            _isFirstThrow = true;
            gameObject.SetActive(true);
        }

        public void GetDirection(Vector3 targetPosition, float x)
        {
            if (x > transform.position.x)
            {
                DirectionX = 1;
            }
            else if (x < transform.position.x)
            {
                DirectionX = -1;
            }
            else
            {
                DirectionX = 0;
            }


            /*
            if (targetPosition.x > transform.position.x)
            {
                Debug.Log("1");
                DirectionX =  1; 
            }
            else if (targetPosition.x < transform.position.x)
            {
                Debug.Log("-1");
                DirectionX =  -1; 
            }
            else
            {
                Debug.Log("0");
                DirectionX =  0; 
            }*/
        }
    }
}
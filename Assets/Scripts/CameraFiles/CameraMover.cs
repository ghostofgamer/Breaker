using System.Collections;
using UnityEngine;

namespace CameraFiles
{
    public class CameraMover : MonoBehaviour
    {
        private const string ChooseLvlMainCameraMoverStart = "ChooseLvlMainCameraMoverStart";

        [SerializeField] private float _speed;
        [SerializeField] private float _overSpeed;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;
        [SerializeField] private Animator _animator;

        private Vector3 _mouseStartPos;
        private Vector3 _cameraStartPos;
        private Vector3 _newCameraPos;
        private bool _freeMovement = true;
        private float _dragSensitivity = 0.1f;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        private WaitForSeconds _waitForMove = new WaitForSeconds(1f);
        private Vector3 _mouseDelta;
        private Vector3 _cameraMovement;
        private Vector3 _targetPosition;

        private void Start()
        {
            StartCoroutine(PlayAnimations());
            _mouseStartPos = Input.mousePosition;
            _cameraStartPos = transform.position;
            _newCameraPos = _cameraStartPos;
        }

        private void Update()
        {
            if ((transform.position != _newCameraPos && !Input.GetMouseButton(0)) ||
                (transform.position != _newCameraPos && !_freeMovement))
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, _newCameraPos, _overSpeed * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0) && _freeMovement)
            {
                _mouseStartPos = Input.mousePosition;
                _cameraStartPos = transform.position;
            }
            else if (Input.GetMouseButton(0) && _freeMovement)
            {
                _mouseDelta = Input.mousePosition - _mouseStartPos;
                _cameraMovement = new Vector3(-_mouseDelta.x, 0, -_mouseDelta.y) * _dragSensitivity;
                _targetPosition = _cameraStartPos + _cameraMovement;
                _targetPosition.x = Mathf.Clamp(_targetPosition.x, _minX, _maxX);
                _targetPosition.z = Mathf.Clamp(_targetPosition.z, _minZ, _maxZ);
                transform.position = Vector3.Lerp(transform.position, _targetPosition, _speed * Time.deltaTime);
                _newCameraPos = _targetPosition;
            }
        }

        public void ChangeTargetPosition(Vector3 position)
        {
            StartCoroutine(SetTarget(position));
        }

        public void EnableFreeMovement()
        {
            _freeMovement = true;
        }

        public void DisableFreeMovement()
        {
            _freeMovement = false;
        }

        public void SpeedUp()
        {
            _overSpeed *= _overSpeed;
        }

        private IEnumerator SetTarget(Vector3 position)
        {
            yield return _waitForSeconds;
            _newCameraPos = position;
        }

        private IEnumerator PlayAnimations()
        {
            _animator.Play(ChooseLvlMainCameraMoverStart);
            yield return _waitForMove;
            _animator.enabled = false;
        }
    }
}
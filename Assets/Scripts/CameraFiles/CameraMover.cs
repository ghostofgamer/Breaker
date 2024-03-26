using System.Collections;
using UnityEngine;

namespace CameraFiles
{
    public class CameraMover : MonoBehaviour
    {
        private const string ChooseLvlMainCameraMoverStart = "ChooseLvlMainCameraMoverStart";

        [SerializeField] private float _sensitivity;
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

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        private WaitForSeconds _waitForMove = new WaitForSeconds(1f);
        
        [SerializeField] private Vector3 _cameraVelocity;
        [SerializeField] private float _smoothing;

        private void Start()
        {
            StartCoroutine(PlayAnimations());
            _mouseStartPos = Input.mousePosition;
            _cameraStartPos = transform.position;
            _newCameraPos = _cameraStartPos;
        }

        private void Update()
        {
            if (transform.position != _newCameraPos && !Input.GetMouseButton(0) ||
                transform.position != _newCameraPos && !_freeMovement)
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
                /*Vector3 mouseDelta = Input.mousePosition - _mouseStartPos;
                Vector3 cameraDelta = new Vector3(mouseDelta.x, 0, mouseDelta.y) * _sensitivity;
                _newCameraPos = _cameraStartPos - cameraDelta;
                _newCameraPos.x = Mathf.Clamp(_newCameraPos.x, _minX, _maxX);
                _newCameraPos.z = Mathf.Clamp(_newCameraPos.z, _minZ, _maxZ);
                transform.position = Vector3.Lerp(transform.position, _newCameraPos, _speed * Time.deltaTime);*/
                
                // transform.position = Vector3.MoveTowards(transform.position, _newCameraPos, _speed * Time.deltaTime);
                
                Vector3 mouseDelta = Input.mousePosition - _mouseStartPos;
                Vector3 cameraDelta = new Vector3(mouseDelta.x, 0, mouseDelta.y) * _sensitivity;
                _newCameraPos = _cameraStartPos - cameraDelta;
                _newCameraPos.x = Mathf.Clamp(_newCameraPos.x, _minX, _maxX);
                _newCameraPos.z = Mathf.Clamp(_newCameraPos.z, _minZ, _maxZ);
                
                _cameraVelocity = Vector3.Lerp(_cameraVelocity, _newCameraPos - transform.position, _smoothing * Time.deltaTime);
                transform.position = Vector3.MoveTowards(transform.position, _newCameraPos, _cameraVelocity.magnitude * Time.deltaTime);
            }
        }

        public void SetTargetPosition(Vector3 position)
        {
            StartCoroutine(SetTarget(position));
        }

        public void SetValue(bool flag)
        {
            _freeMovement = flag;
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
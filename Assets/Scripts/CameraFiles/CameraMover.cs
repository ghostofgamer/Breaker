using System.Collections;
using UnityEngine;

namespace CameraFiles
{
    public class CameraMover : MonoBehaviour
    {
        [SerializeField] private float _sensitivity;
        [SerializeField] private float _speed;
        [SerializeField] private float _overSpeed;
        [SerializeField] private float _minX;
        [SerializeField] private float _maxX;
        [SerializeField] private float _minZ;
        [SerializeField] private float _maxZ;
        [SerializeField] private Animator _animator;

        private const string ChooseLvlMainCameraMoverStart = "ChooseLvlMainCameraMoverStart";
        
        private Vector3 _mouseStartPos;
        private Vector3 _cameraStartPos;
        private Vector3 _newCameraPos;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.1f);
        private WaitForSeconds _waitForMove = new WaitForSeconds(1f);

        private void Start()
        {
            StartCoroutine(PlayAnimations());
            _mouseStartPos = Input.mousePosition;
            _cameraStartPos = transform.position;
            _newCameraPos = _cameraStartPos;
        }

        void Update()
        {
            if (transform.position != _newCameraPos && !Input.GetMouseButton(0))
            {
                transform.position = Vector3.MoveTowards(transform.position, _newCameraPos, _overSpeed * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _mouseStartPos = Input.mousePosition;
                _cameraStartPos = transform.position;
            }
            
            else if (Input.GetMouseButton(0))
            {
                Vector3 mouseDelta = Input.mousePosition - _mouseStartPos;
                Vector3 cameraDelta = new Vector3(mouseDelta.x, 0, mouseDelta.y) * _sensitivity;
                _newCameraPos = _cameraStartPos - cameraDelta;
                _newCameraPos.x = Mathf.Clamp(_newCameraPos.x, _minX, _maxX);
                _newCameraPos.z = Mathf.Clamp(_newCameraPos.z, _minZ, _maxZ);
                transform.position = Vector3.Lerp(transform.position, _newCameraPos, _speed * Time.deltaTime);
            }
        }

        public void SetTargetPosition(Vector3 position)
        {
            StartCoroutine(SetTarget(position));
            _newCameraPos = position;
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
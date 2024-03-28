using System.Collections;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace CameraFiles
{
    public class PlatformFollower : MonoBehaviour
    {
        private const string MouseX = "Mouse X";

        [SerializeField] private Animator _animator;
        [SerializeField] private PlatformaMover _platformaMover;

        private float _sensitivity = 1;
        private float _maxRotationY = 3;
        private float _minRotationY = -3;
        private float _speedRotation = 1;
        private Vector3 _rotation;
        private Vector3 _position;
        private Vector3 _targetRotation;
        private bool _isWork = false;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
        private float _mouseX;

        private void Start()
        {
            _rotation = transform.eulerAngles;
            _targetRotation = _rotation;
            _position = transform.position;
            StartCoroutine(SetActive());
        }

        private void Update()
        {
            if (!_isWork)
                return;

            if (Input.GetMouseButton(0) && _platformaMover.IsAlive && _platformaMover.DirectionX != 0)
            {
                _mouseX = Input.GetAxis(MouseX) * _sensitivity;
                _targetRotation.y += -_mouseX;
                _position.x += _mouseX;
                _targetRotation.y = Mathf.Clamp(_targetRotation.y, _minRotationY, _maxRotationY);
                _position.x = Mathf.Clamp(_position.x, _minRotationY, _maxRotationY);
                transform.position = Vector3.Lerp(transform.position, _position, Time.deltaTime * _speedRotation);
                _rotation = Vector3.Lerp(_rotation, _targetRotation, Time.deltaTime * _speedRotation);
                transform.eulerAngles = _rotation;
            }
        }

        private IEnumerator SetActive()
        {
            yield return _waitForSeconds;
            _animator.enabled = false;
            _isWork = true;
        }
    }
}
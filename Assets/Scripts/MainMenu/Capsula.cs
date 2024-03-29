using UnityEngine;

namespace MainMenu
{
    public class Capsula : MonoBehaviour
    {
        [SerializeField] private GameObject _gameObject;

        private Quaternion _originalRotation;
        private bool _isSelected = false;
        private float _speed = 65f;
        private float _speedBack = 10f;
        private bool _rotate;
        private float _angle = 35f;
        private float _cameraAngle;
        private float _capsulaAngle;

        private void Start()
        {
            _originalRotation = transform.rotation;
        }

        private void Update()
        {
            if (_isSelected)
            {
                if (!_rotate)
                {
                    transform.rotation = Quaternion.Euler(0, 0, _angle);
                    _rotate = true;

                    if (Camera.main != null)
                    {
                        _cameraAngle = Camera.main.transform.eulerAngles.x;
                        _capsulaAngle = _cameraAngle - _cameraAngle;
                        transform.eulerAngles = new Vector3(_cameraAngle, _capsulaAngle, _angle);
                    }
                }

                _gameObject.GetComponent<RectTransform>().Rotate(Vector3.up * _speed * Time.deltaTime);
            }
            else
            {
                transform.rotation =
                    Quaternion.Slerp(transform.rotation, _originalRotation, Time.deltaTime * _speedBack);
                _rotate = false;
            }
        }

        public void StartRotate(bool selected)
        {
            _isSelected = selected;
        }
    }
}
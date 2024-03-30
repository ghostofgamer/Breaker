using GameScene.BallContent;
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class BaseInput : MonoBehaviour
    {
        [SerializeField] private GameObject _positionMouse;
        [SerializeField] private BaseMovement _baseMovement;
        [SerializeField] private SlowMo _slowMo;
        [SerializeField] private Ball _ball;

        private bool _isFirstThrow = true;
        private string _mouseX = "Mouse X";
        private float _factor = 2f;
        private bool _isMousePressed = false;

        private void Update()
        {
            float mouse = Input.GetAxis(_mouseX) * _factor;

            if (Input.GetMouseButtonDown(0))
            {
                _isMousePressed = true;
                _positionMouse.SetActive(true);
                _slowMo.DisableSlowMoEffect();
            }

            if (Input.GetMouseButtonUp(0))
            {
                _isMousePressed = false;

                if (!_ball.IsMoving)
                    _ball.SetMove(true, mouse);

                _positionMouse.SetActive(false);

                if (!_isFirstThrow)
                    _slowMo.EnableSlowMotionEffect();

                if (_isFirstThrow)
                    _isFirstThrow = false;
            }

            if (_isMousePressed)
            {
                _baseMovement.MovePlatformWithMouse();
            }
        }

        public void ResetThrow()
        {
            _isFirstThrow = true;
        }

        public void DisablePressed()
        {
            _isMousePressed = false;
        }
    }
}
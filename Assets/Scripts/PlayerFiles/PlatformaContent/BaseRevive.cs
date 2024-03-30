using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class BaseRevive : Base
    {
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private ParticleSystem _loseEffect;
        [SerializeField] private BaseInput _baseInput;

        private float _positionY = 5.1f;
        private float _positionZ = -6.5f;

        public void GetLife()
        {
            transform.position = new Vector3(0, _positionY, _positionZ);
            _loseEffect.transform.parent = gameObject.transform;
            _loseEffect.transform.position = gameObject.transform.position;
            _baseInput.DisablePressed();
            _baseInput.ResetThrow();
            Live();
            _mousePosition.SetActive(true);
        }
    }
}
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    [RequireComponent(typeof(PlatformaMovement))]
    public class PlatformaRevive : MonoBehaviour
    {
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private ParticleSystem _loseEffect;

        private PlatformaMovement _platformaMovement;
        private float _positionY = 5.1f;
        private float _positionZ = -6.5f;

        private void Start()
        {
            _platformaMovement = GetComponent<PlatformaMovement>();
        }

        public void GetLife()
        {
            transform.position = new Vector3(0, _positionY, _positionZ);
            _loseEffect.transform.parent = gameObject.transform;
            _loseEffect.transform.position = gameObject.transform.position;
            _platformaMovement.Revive();
            _mousePosition.SetActive(true);
        }
    }
}
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class PlatformaRevive : MonoBehaviour
    {
        [SerializeField] private GameObject _mousePosition;
        [SerializeField] private ParticleSystem _loseEffect;

        private PlatformaMover _platformaMover;

        private void Start()
        {
            _platformaMover = GetComponent<PlatformaMover>();
        }

        public void Revive()
        {
            transform.position = new Vector3(0, 5.1f, -6.5f);
            _loseEffect.transform.parent = gameObject.transform;
            _loseEffect.transform.position = gameObject.transform.position;
            _platformaMover.Revive();
            _mousePosition.SetActive(true);
        }
    }
}
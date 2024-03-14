using UnityEngine;

namespace GameScene.BallContent
{
    public class PortalTeleporterBall : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particleSystem;
        [SerializeField] private ParticleSystem _missileEffect;
        [SerializeField] private float _xMinPosition;
        [SerializeField] private float _xMaxPosition;
        [SerializeField] private float _zMaxPosition;
        [SerializeField] private float _zMinPosition;
        [SerializeField] private WallTrigger[] _wallTrigger;

        public void Init(ParticleSystem missileEffect)
        {
            _missileEffect = missileEffect;
        }
        
        public void TeleportBall()
        {
            if (transform.position.x > _xMaxPosition)
            {
                Teleport(new Vector3(_xMinPosition, transform.position.y, transform.position.z));
            }

            if (transform.position.x < _xMinPosition)
            {
                Teleport(new Vector3(_xMaxPosition, transform.position.y, transform.position.z));
            }

            if (transform.position.z < _zMinPosition)
            {
                Teleport(new Vector3(transform.position.x, transform.position.y, _zMaxPosition));
            }

            if (transform.position.z > _zMaxPosition)
            {
                Teleport(new Vector3(transform.position.x, transform.position.y, _zMinPosition));
            }
        }

        private void Teleport(Vector3 position)
        {
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
            _missileEffect.gameObject.SetActive(false);
            transform.position = position;
            _missileEffect.gameObject.SetActive(true);
            Instantiate(_particleSystem, transform.position, Quaternion.identity);
        }
    }
}
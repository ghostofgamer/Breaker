using PlayerFiles.PlatformaContent;
using UnityEngine;
using UnityEngine.Events;

namespace GameScene.BallContent
{
    public class BallTrigger : MonoBehaviour
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";

        [SerializeField] private BallMover _ballMover;
        [SerializeField] private LayerMask _platformLayer;
        [SerializeField] private AudioSource _audioSource;

        private bool _isHit;
        private bool _isBackHit;
        private int _factor = 2;
        private float _valueEnableFastSpeed = 0.5f;
        private float _valuePush = 0.3f;

        public event UnityAction Dying;
        
        public event UnityAction Bounce;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Bourder bourder))
            {
                Dying?.Invoke();
                gameObject.SetActive(false);
                GetComponent<Ball>().StopMove();
                Time.timeScale = 1;
            }

            if (other.collider.TryGetComponent(out PlatformaMover platformaMover))
            {
                float mouse = Input.GetAxis(MouseX) * _factor;
                float mouseY = Input.GetAxis(MouseY);
                Bounce?.Invoke();
                _audioSource.PlayOneShot(_audioSource.clip);
                ContactPoint contact = other.contacts[0];
                Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
                Vector3 platformNormal = contact.normal;
                ChangeDirection(newVector, platformNormal);
            }
        }

        public void CheckPlatformCollision()
        {
            float mouse = Input.GetAxis(MouseX) * _factor;
            float mouseY = Input.GetAxis(MouseY);
            Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
            float maxDistance = 2.1f;
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, transform.lossyScale.x / _factor, _ballMover.Direction, out hit, maxDistance, _platformLayer))
            {
                if (hit.collider.gameObject.TryGetComponent(out PlatformaMover platformaMover))
                {
                    Bounce?.Invoke();
                    _audioSource.PlayOneShot(_audioSource.clip);
                    ChangeDirection(newVector, hit.normal);
                }
            }
        }

        private void ChangeDirection(Vector3 vector, Vector3 hit)
        {
            Vector3 reflect = Vector3.Reflect(_ballMover.Direction, hit);
            Vector3 newReflect = new Vector3(reflect.x, reflect.y, 1).normalized;

            if (vector.z > _valueEnableFastSpeed)
            {
                _ballMover.SetDirection(new Vector3(reflect.x, reflect.y, reflect.z + vector.z).normalized);
                _ballMover.FastSpeed();
            }
            else
            {
                _ballMover.SetDirection(newReflect);
            }

            if (vector.x > _valuePush || vector.x < -_valuePush)
            {
                _ballMover.SetDirection(new Vector3(reflect.x + vector.x, reflect.y, newReflect.z).normalized);
            }
            else
            {
                _ballMover.SetDirection(newReflect);
            }
        }
    }
}
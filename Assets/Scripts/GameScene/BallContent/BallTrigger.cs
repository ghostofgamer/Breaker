using System;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace GameScene.BallContent
{
    public class BallTrigger : MonoBehaviour
    {
        private const string MouseX = "Mouse X";
        private const string MouseY = "Mouse Y";

        [SerializeField] private BallMover _ballMover;
        [SerializeField] private LayerMask _platformLayer;
        [SerializeField] private AudioSource _audioSource;

        private int _factor = 2;

        public event Action Dying;

        public event Action Bounced;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Bourder bourder))
            {
                Dying?.Invoke();
                gameObject.SetActive(false);
                GetComponent<Ball>().OnStopMove();
                Time.timeScale = 1;
            }

            if (other.collider.TryGetComponent(out PlatformaMovement platformaMover))
            {
                float mouse = Input.GetAxis(MouseX) * _factor;
                float mouseY = Input.GetAxis(MouseY);
                Bounced?.Invoke();
                _audioSource.PlayOneShot(_audioSource.clip);
                ContactPoint contact = other.contacts[0];
                Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
                Vector3 platformNormal = contact.normal;
                _ballMover.ChangeDirection(newVector, platformNormal);
            }
        }

        public void CheckPlatformCollision()
        {
            float mouse = Input.GetAxis(MouseX) * _factor;
            float mouseY = Input.GetAxis(MouseY);
            Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
            float maxDistance = 2.1f;
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, transform.lossyScale.x / _factor, _ballMover.Direction, out hit,
                maxDistance, _platformLayer))
            {
                if (hit.collider.gameObject.TryGetComponent(out PlatformaMovement platformaMover))
                {
                    Bounced?.Invoke();
                    _audioSource.PlayOneShot(_audioSource.clip);
                    _ballMover.ChangeDirection(newVector, hit.normal);
                }
            }
        }
    }
}
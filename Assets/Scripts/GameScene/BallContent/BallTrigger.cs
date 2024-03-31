using System;
using Bricks;
using PlayerFiles.ModificationContent;
using PlayerFiles.PlatformaContent;
using UnityEngine;

namespace GameScene.BallContent
{
    public class BallTrigger : MonoBehaviour
    {
        [SerializeField] private LayerMask _platformLayer;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private BallDirection _ballDirection;
        [SerializeField] private ElectricBall _electricBall;
        [SerializeField]private BallDeath _ballDeath;
        
        private int _factor = 2;

        public event Action Bounced;

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Bourder bourder))
            {
                _ballDeath.Die();
            }

            if (other.collider.TryGetComponent(out BaseMovement platformaMover))
            {
                Bounced?.Invoke();
                _audioSource.PlayOneShot(_audioSource.clip);
                ContactPoint contact = other.contacts[0];
                Vector3 platformNormal = contact.normal;
                _ballDirection.DirectReflection(platformNormal);
            }

            if (other.collider.TryGetComponent(out Brick brick))
            {
                if (_electricBall.gameObject.activeSelf && !brick.IsEternal)
                {
                    _electricBall.DestroyBrick(brick);
                    return;
                }

                _ballDirection.ReflectBall(other.GetContact(0).normal);
                brick.Die();
            }

            if (other.collider.TryGetComponent(out Wall wall) ||
                other.collider.TryGetComponent(out WallTrigger wallTrigger))
            {
                _ballDirection.ReflectBall(other.GetContact(0).normal);
            }
        }

        public void CheckPlatformCollision()
        {
            float maxDistance = 2.1f;
            RaycastHit hit;

            if (Physics.SphereCast(
                transform.position,
                transform.lossyScale.x / _factor,
                _ballDirection.Direction,
                out hit,
                maxDistance, _platformLayer))
            {
                if (hit.collider.gameObject.TryGetComponent(out BaseMovement platformaMover))
                {
                    Bounced?.Invoke();
                    _audioSource.PlayOneShot(_audioSource.clip);
                    _ballDirection.DirectReflection(hit.normal);
                }
            }
        }
    }
}
using PlayerFiles.PlatformaContent;
using UnityEngine;
using UnityEngine.Events;

namespace GameScene.BallContent
{
    public class BallTrigger : MonoBehaviour
    {
        [SerializeField] private BallMover _ballMover;
        [SerializeField] private LayerMask _platformLayer;
        [SerializeField]private AudioSource _audioSource;

        private MeshRenderer _meshRenderer;
        private bool _isHit;
        private bool _isBackHit;
        private float _platformOffset = 3f;
        private float _sphereRadius = 0.5f;
        
        public event UnityAction Dying;
        public event UnityAction Bounce;
        
        public void Init(MeshRenderer meshRenderer)
        {
            _meshRenderer = meshRenderer;
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.collider.TryGetComponent(out Bourder bourder))
            {
                Dying?.Invoke();
                gameObject.SetActive(false);
                GetComponent<Ball>().StopMove();
                Time.timeScale = 1;
            }
        }

        public void CheckPlatformCollision()
        {
            float mouse = Input.GetAxis("Mouse X") * 2;
            float mouseY = Input.GetAxis("Mouse Y");
            Vector3 newVector = new Vector3(mouse, 0, mouseY).normalized;
            float maxDistance = 2.1f;
            RaycastHit hit;

            // Vector3 predictedPosition = transform.position + _ballMover.Direction * (_ballMover.Speed * Time.deltaTime);

            /*bool isHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, _ballMover.Direction, out hit,
            maxDistance, platformLayer);

        bool isBackHit = Physics.SphereCast(transform.position, transform.lossyScale.x / 2, -_ballMover.Direction,
            out hit,
            maxDistance, platformLayer);*/

            if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, _ballMover.Direction, out hit,
                maxDistance, _platformLayer))
            {
                if (hit.collider.gameObject.TryGetComponent(out PlatformaMover platformaMover))
                {
                    Bounce?.Invoke();
                    _audioSource.PlayOneShot(_audioSource.clip);
                    ChangeDirection(newVector, hit);
                }
            }

            /*if (Physics.SphereCast(transform.position, transform.lossyScale.x / 2, -_ballMover.Direction, out hit,
            maxDistance, platformLayer))
        {
            if (hit.collider.gameObject.TryGetComponent<PlatformaMover>(out PlatformaMover зlatformaMover))
            {
                // Debug.Log("BackHit");
                ChangeDirection(New, hit);
                // Debug.Log("NEWDIRECTION" + _ballMover.Direction);
            }
        }*/


            // ChangeDirection(New,hitColliders[i]);
        }

        private void ChangeDirection(Vector3 vector, RaycastHit hit)
        {
            _meshRenderer.enabled = false;
            Vector3 platformUp = hit.transform.forward;
            Vector3 newPosition = hit.point + platformUp * _platformOffset;
            _meshRenderer.enabled = true;

            Vector3 reflect = Vector3.Reflect(_ballMover.Direction, hit.normal);
            Vector3 newReflect = new Vector3(reflect.x, reflect.y, 1).normalized;

            if (vector.z > 0.5)
            {
                _ballMover.SetDirection(new Vector3(reflect.x, reflect.y, reflect.z + vector.z).normalized);
                // Vector3 direction = new Vector3(reflect.x, reflect.y, newReflect.z + vector.z).normalized;
                _ballMover.FastSpeed();
            }
            else
            {
                _ballMover.SetDirection(newReflect);
            }

            if (vector.x > 0.3 || vector.x < -0.3)
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
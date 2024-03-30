using UnityEngine;

namespace CameraFiles
{
    public class CameraDistance : MonoBehaviour
    {
        [SerializeField] private CameraMover _cameraMover;

        private float _distance = 80f;
        private Vector3 _targetPosition;

        public void AssignMovementTarget(Transform target)
        {
            _targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z - _distance);
            _cameraMover.ChangeTargetPosition(_targetPosition);
            _cameraMover.DisableFreeMovement();
        }
    }
}
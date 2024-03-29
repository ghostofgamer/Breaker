using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class MirrorMovement : MonoBehaviour
    {
        [SerializeField] private Transform _originalPlatform;

        private void Update()
        {
            if (_originalPlatform != null)
            {
                transform.position = new Vector3(-_originalPlatform.position.x, _originalPlatform.position.y, _originalPlatform.position.z);
            }
        }
    }
}
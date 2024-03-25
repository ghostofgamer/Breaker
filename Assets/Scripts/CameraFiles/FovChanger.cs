using UnityEngine;

namespace CameraFiles
{
    public class FovChanger : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private int _fov = 55;

        private void Start()
        {
            if (!Application.isMobilePlatform)
                _camera.fieldOfView = _fov;
        }
    }
}
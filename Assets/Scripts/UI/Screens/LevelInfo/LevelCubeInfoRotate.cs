using UnityEngine;

namespace UI.Screens.LevelInfo
{
    public class LevelCubeInfoRotate : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            transform.Rotate(Vector3.right * _speed * Time.deltaTime);
        }
    }
}
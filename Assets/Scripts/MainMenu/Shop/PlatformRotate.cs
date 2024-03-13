using UnityEngine;

namespace MainMenu.Shop
{
    public class PlatformRotate : MonoBehaviour
    {
        private void Update()
        {
            transform.Rotate(Vector3.up * (30f * Time.deltaTime));
        }
    }
}

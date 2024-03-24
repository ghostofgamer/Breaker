using UnityEngine;

namespace BulletFiles
{
    public class BulletMover : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private void Update()
        {
            // transform.position += transform.forward * (_speed * Time.deltaTime);
            transform.position += transform.up * (_speed * Time.deltaTime);
        }
    }
}

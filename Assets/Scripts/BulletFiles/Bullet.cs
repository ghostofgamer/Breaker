using UnityEngine;

namespace BulletFiles
{
    public class Bullet : MonoBehaviour
    {
        public void Init(Vector3 shootPosition)
        {
            transform.position = shootPosition;
        }
    }
}

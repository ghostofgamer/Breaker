using UnityEngine;

namespace BulletFiles
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] protected BulletMover BulletMover;

        public void Init(Vector3 shootPosition)
        {
            transform.position = shootPosition;
            BulletMover.enabled = true;
        }
    }
}
using UnityEngine;

namespace PlayerFiles.PlatformaContent
{
    public class Platforma : Player
    {
        public Vector3 StartSize { get; private set; }

        private void Start()
        {
            StartSize = transform.localScale;
        }
    }
}
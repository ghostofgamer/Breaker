using UnityEngine;

namespace Others
{
    public class AnimationsController : MonoBehaviour
    {
        private const string Rotate = "Rotate";
        private const string Victory = "Victory";
        private const string BrickRingOpen = "BrickRingOpen";
        private const string BrickRingClose = "BrickRingClose";
        private const string WaveMotion = "WaveMotion";

        [SerializeField] private Animator _animator;

        public void PlayRotate()
        {
            _animator.Play(Rotate);
        }

        public void PlayVictory()
        {
            _animator.SetTrigger(Victory);
        }

        public void RingOpen()
        {
            _animator.Play(BrickRingOpen);
        }

        public void RingClose()
        {
            _animator.Play(BrickRingClose);
        }

        public void PlayWave()
        {
            _animator.Play(WaveMotion);
        }
    }
}
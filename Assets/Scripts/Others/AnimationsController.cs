using UnityEngine;

namespace Others
{
    public class AnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string Rotate = "Rotate";
        private const string Victory = "Victory";
        private const string BrickRingOpen = "BrickRingOpen";
        private const string BrickRingClose = "BrickRingClose";
        private const string WaveMotion = "WaveMotion";

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
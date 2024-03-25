using UnityEngine;

namespace Others
{
    public class AnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string Rotate = "Rotate";
        private const string Victory = "Victory";
        
        public void PlayRotate()
        {
            _animator.Play(Rotate);
        }
        
        public void PlayVictory()
        {
            _animator.SetTrigger(Victory);
        }
    }
}
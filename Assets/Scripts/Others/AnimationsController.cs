using UnityEngine;

namespace Others
{
    public class AnimationsController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string Rotate = "Rotate";

        public void PlayRotate()
        {
            _animator.Play(Rotate);
        }
    }
}
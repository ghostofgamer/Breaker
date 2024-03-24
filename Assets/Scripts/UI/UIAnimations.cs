using UnityEngine;

namespace UI
{
    public class UIAnimations : MonoBehaviour
    {
        private const string OpenScreen = "Open";
        private const string CloseScreen = "Close";

        [SerializeField] private Animator _animator;

        public void Open()
        {
            _animator.Play(OpenScreen);
        }

        public void Close()
        {
            _animator.Play(CloseScreen);
        }
    }
}
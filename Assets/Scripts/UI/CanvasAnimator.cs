using System.Collections;
using UnityEngine;

namespace UI
{
    public class CanvasAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _blockPanel;
        [SerializeField] private UIAnimations _uiAnimations;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void Start()
        {
            Open();
        }

        public void Close()
        {
            SetActive(true);
            _uiAnimations.Close();
        }

        private void Open()
        {
            StartCoroutine(OpenScene());
        }

        private IEnumerator OpenScene()
        {
            _uiAnimations.Open();
            yield return _waitForSeconds;
            SetActive(false);
        }

        private void SetActive(bool flag)
        {
            _blockPanel.SetActive(flag);
            _animator.enabled = flag;
        }
    }
}
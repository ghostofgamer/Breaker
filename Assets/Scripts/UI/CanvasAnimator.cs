using System.Collections;
using UnityEngine;

namespace UI
{
    public class CanvasAnimator : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _blockPanel;
    
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);
    
        private void Start()
        {
            Open();
        }

        public void Open()
        {  
            StartCoroutine(OpenScene());
        }

        public void Close()
        {
            SetActive(true);
            _animator.Play("CanvasMainMenuCloseAnimations");
        }

        private IEnumerator OpenScene()
        {
            _animator .Play("CanvasMainMenuStartAnimations");
            yield return _waitForSeconds;
            SetActive(false);
            /*_blockPanel.SetActive(false);
        _animator.enabled = false;*/
        }

        private void SetActive(bool flag)
        {
            _blockPanel.SetActive(flag);
            _animator.enabled = flag;
        }
    }
}

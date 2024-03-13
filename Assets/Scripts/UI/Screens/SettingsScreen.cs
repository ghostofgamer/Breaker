using System.Collections;
using UnityEngine;

namespace UI.Screens
{
    public class SettingsScreen : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private CanvasGroup _canvasGroup;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            Setvalue(0, false);
        }

        public void Open()
        {
            Setvalue(1, true);
            _animator.Play("Open");
            Time.timeScale = 0;
            Debug.Log("TimeScale " + Time.timeScale);
        }

        public void Close()
        {
            StartCoroutine(CloseScreen());
        }

        private IEnumerator CloseScreen()
        {
            _animator.Play("Close");
            yield return _waitForSeconds;
            Debug.Log("выкл");
            Setvalue(0, false);
        }

        private void Setvalue(int alpha, bool flag)
        {
            if (_canvasGroup != null)
            {
                _canvasGroup.alpha = alpha;
                _canvasGroup.interactable = flag;
                _canvasGroup.blocksRaycasts = flag;
            }
        }
    }
}
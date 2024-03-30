using System.Collections;
using CameraFiles;
using UI.Screens.LevelInfo;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.Buttons
{
    public class SelectLevelButton : AbstractButton
    {
        [SerializeField] private int _sceneNumber;
        [SerializeField] private Transform _target;
        [SerializeField] private CameraMover _cameraMover;
        [SerializeField] private CanvasAnimator _canvasAnimator;
        [SerializeField] private BackToMenuButton _backToMenuButton;
        [SerializeField] private LevelInfo _levelInfo;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(1f);

        protected override void OnClick()
        {
            _audioSource.PlayOneShot(_audioSource.clip);
            _levelInfo.Close();
            StartCoroutine(SelectLevel());
        }

        private IEnumerator SelectLevel()
        {
            _cameraMover.ChangeTargetPosition(_target.position);
            _cameraMover.SpeedUp();
            _canvasAnimator.Close();
            _backToMenuButton.FadeBackGround();
            yield return _waitForSeconds;
            SceneManager.LoadScene(_sceneNumber);
        }
    }
}
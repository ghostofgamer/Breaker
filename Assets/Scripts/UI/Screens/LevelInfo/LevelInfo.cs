using System.Collections;
using CameraFiles;
using Enum;
using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace UI.Screens.LevelInfo
{
    public class LevelInfo : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private GameObject _cubePositionInfo;
        [SerializeField] private GameObject[] _cubePositionsInfo;
        [SerializeField] private GameObject _panelCompleted;
        [SerializeField] private GameObject _lockedPanel;
        [SerializeField] private GameObject _unLockedPanel;
        [SerializeField] private int _index;
        [SerializeField] private Load _load;
        [SerializeField] private TMP_Text _score;
        [SerializeField] private ColliderController _colliderController;
        [SerializeField] private CloseChangeLevelScreenButton[] _closeChangeLevelScreenButton;
        [SerializeField] private CloseChangeLevelScreenButton _closeChangeLevelScreenButtonOne;
        [SerializeField] private AudioSource _audioSource;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
        private Coroutine _coroutineOpen;
        private Coroutine _coroutineClose;

        private bool _information;

        public bool IsOpen { get; private set; }

        private void Start()
        {
            _information = _load.Get("LevelStatus" + _index, 0) > 0;
            _panelCompleted.SetActive((LevelState) _load.Get("LevelStatus" + _index, 0) == LevelState.Completed);
            _score.text = _load.Get(Save.Score + _index, 0).ToString();
            SetActive(0, false);
            _cubePositionInfo = _cubePositionsInfo[_information ? 0 : 1];
            _unLockedPanel.SetActive(_information ? true : false);
            _lockedPanel.SetActive(!_information);
        }

        public void Open()
        {
            Debug.Log("OPEN" + this.name);
     
            /*Debug.Log("OPEN");
            _closeChangeLevelScreenButton.Init(this);
            _closeChangeLevelScreenButton.gameObject.SetActive(true);*/

            /*foreach (var closeChangeLevelScreenButton in _closeChangeLevelScreenButton)
            {
                closeChangeLevelScreenButton.gameObject.SetActive(true);
            }*/

            if (_coroutineOpen != null)
                StopCoroutine(_coroutineOpen);

            StartCoroutine(OpenScreen());
        }

        public void Close()
        {
            Debug.Log("CLOSE" + this.name);
            if (_coroutineClose != null)
                StopCoroutine(_coroutineClose);

            StartCoroutine(CloseScreen());
        }

        private IEnumerator OpenScreen()
        {
            yield return _waitForSeconds;
            IsOpen = true;
            SetActive(1, true);
            _audioSource.PlayOneShot(_audioSource.clip);
            _animator.Play("LevelCubeInfoScreenUp");
            Debug.Log("IsOpen" + IsOpen + this.name);
            // _colliderController.SetValue(false);
            // _colliderController.SetValueEnabled(false);
        }

        private IEnumerator CloseScreen()
        {
            // _colliderController.SetValue(true);
            // _colliderController.SetValueEnabled(true);
            _animator.Play("LevelCubeInfoScreenDown");
            _audioSource.PlayOneShot(_audioSource.clip);
            IsOpen = false;
            Debug.Log("IsClose" + IsOpen + this.name);
            yield return _waitForSeconds;
            SetActive(0, false);
        }

        private void SetActive(int alpha, bool flag)
        {
            _closeChangeLevelScreenButtonOne.gameObject.SetActive(flag);
            _cubePositionInfo.SetActive(flag);
            _canvasGroup.alpha = alpha;
            _canvasGroup.interactable = flag;
            _canvasGroup.blocksRaycasts = flag;
        }

        /*
    public void SelectComplitedInfo()
    {
        _panelComplited.SetActive(true);
    }*/
    }
}
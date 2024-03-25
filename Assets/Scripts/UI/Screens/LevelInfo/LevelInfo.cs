using System.Collections;
using Enum;
using SaveAndLoad;
using TMPro;
using UnityEngine;

namespace UI.Screens.LevelInfo
{
    public class LevelInfo : MonoBehaviour
    {
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
        [SerializeField] private CloseChangeLevelScreenButton _closeChangeLevelScreenButtonOne;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private UIAnimations _uiAnimations;

        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.5f);
        private Coroutine _coroutineOpen;
        private Coroutine _coroutineClose;
        private bool _information;
        private int _zeroAlpha = 0;
        private int _fullAlpha = 1;
        private int _defaultValue = 0;
        private int _indexFalseInformation = 1;

        public bool IsOpen { get; private set; }

        private void Start()
        {
            Initialization();
        }

        public void Open()
        {
            if (_coroutineOpen != null)
                StopCoroutine(_coroutineOpen);

            StartCoroutine(OpenScreen());
        }

        public void Close()
        {
            if (_coroutineClose != null)
                StopCoroutine(_coroutineClose);

            StartCoroutine(CloseScreen());
        }

        private void Initialization()
        {
            _information = _load.Get(Save.LevelStatus + _index, _defaultValue) > _defaultValue;
            _panelCompleted.SetActive((LevelState) _load.Get(Save.LevelStatus + _index, _defaultValue) == LevelState.Completed);
            _score.text = _load.Get(Save.Score + _index, _defaultValue).ToString();
            SetActive(_zeroAlpha, false);
            _cubePositionInfo = _cubePositionsInfo[_information ? 0 : _indexFalseInformation];
            _unLockedPanel.SetActive(_information);
            _lockedPanel.SetActive(!_information);
        }

        private IEnumerator OpenScreen()
        {
            yield return _waitForSeconds;
            IsOpen = true;
            SetActive(_fullAlpha, true);
            _audioSource.PlayOneShot(_audioSource.clip);
            _uiAnimations.Open();
            _colliderController.SetValue(false);
        }

        private IEnumerator CloseScreen()
        {
            _colliderController.SetValue(true);
            _uiAnimations.Close();
            _audioSource.PlayOneShot(_audioSource.clip);
            IsOpen = false;
            yield return _waitForSeconds;
            SetActive(_zeroAlpha, false);
        }

        private void SetActive(int alpha, bool flag)
        {
            _closeChangeLevelScreenButtonOne.gameObject.SetActive(flag);
            _cubePositionInfo.SetActive(flag);
            _canvasGroup.alpha = alpha;
            _canvasGroup.interactable = flag;
            _canvasGroup.blocksRaycasts = flag;
        }
    }
}
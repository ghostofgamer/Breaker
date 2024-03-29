using CameraFiles;
using Enum;
using UI.Screens;
using UI.Screens.LevelInfo;
using UnityEngine;

namespace Levels
{
    [RequireComponent(typeof(BoxCollider))]
    public class Level : MonoBehaviour
    {
        [SerializeField] private EffectInstaller _effectInstaller;
        [SerializeField] private ParticleSystem[] _line;
        [SerializeField] private LevelInfo _levelInfo;
        [SerializeField] private LevelInfo[] _levelsInfo;
        [SerializeField] private Color _notPassedColor;
        [SerializeField] private Color _passedColor;
        [SerializeField] private Color _notOpenColor;
        [SerializeField] private Level[] _nextLevel;
        [SerializeField] private Level[] _allLevels;
        [SerializeField] private LevelCubeJumping _levelCubeJumping;
        [SerializeField] private CameraDistance _cameraDistance;
        [SerializeField] private int _index;
        [SerializeField] private ShopScreen _shopScreen;

        private LevelState _state;
        private BoxCollider _boxCollider;

        public Level[] Nextlevel => _nextLevel;

        public int Index => _index;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnMouseDown()
        {
            if (_shopScreen.IsOpen)
                return;

            foreach (Level level in _allLevels)
                level.GetComponent<EffectInstaller>().StopParticles();

            _effectInstaller.ActivationEffects();
            _effectInstaller.SelectedEffectPlay();
            _cameraDistance.MoveCameraToTarget(transform);

            foreach (LevelInfo levelInfo in _levelsInfo)
            {
                if (levelInfo.IsOpen)
                    levelInfo.Close();
            }

            _levelInfo.Open();
        }

        public void Init(LevelState levelState)
        {
            _state = levelState;

            switch (levelState)
            {
                case LevelState.Locked:
                    _effectInstaller.ColorChanger(_notOpenColor);
                    break;
                case LevelState.Unlocked:
                    _levelCubeJumping.enabled = true;
                    _effectInstaller. ColorChanger(_notPassedColor);
                    break;
                case LevelState.Completed:
                    _effectInstaller. ColorChanger(_passedColor);
                    break;
            }
        }

        public void SetValueCollider(bool flag)
        {
            _boxCollider.enabled = flag;
        }

        public void SetLevels()
        {
            if (_nextLevel.Length > 0)
            {
                for (int i = 0; i < _nextLevel.Length; i++)
                {
                    var moduleMain = _line[i].main;

                    if (_state == LevelState.Completed && _nextLevel[i]._state == LevelState.Completed)
                    {
                        moduleMain.startColor = _passedColor;
                        _effectInstaller.LineMoveActivation(i);
                    }
                    else if ((_state == LevelState.Unlocked && _nextLevel[i]._state == LevelState.Unlocked) ||
                             (_state == LevelState.Completed && _nextLevel[i]._state == LevelState.Unlocked) ||
                             (_state == LevelState.Unlocked && _nextLevel[i]._state == LevelState.Completed))
                    {
                        moduleMain.startColor = _notPassedColor;
                    }
                    else
                    {
                        moduleMain.startColor = _notOpenColor;
                    }
                }
            }
        }
    }
}
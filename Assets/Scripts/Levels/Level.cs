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

        public LevelState State => _state;

        public Level[] NextLevel => _nextLevel;

        public int Index => _index;
        
        protected Color NotPassedColor => _notPassedColor;

        protected Color PassedColor => _passedColor;

        protected Color NotOpenColor => _notOpenColor;


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
                    _effectInstaller.ColorChanger(_notPassedColor);
                    break;
                case LevelState.Completed:
                    _effectInstaller.ColorChanger(_passedColor);
                    break;
            }
        }

        public void Activation()
        {
            SetValueCollider(true);
        }

        public void Deactivation()
        {
            SetValueCollider(false);
        }

        private void SetValueCollider(bool flag)
        {
            _boxCollider.enabled = flag;
        }
    }
}
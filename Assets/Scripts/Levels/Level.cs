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
        [SerializeField] private EffectChanger _effectChanger;
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

        protected EffectChanger EffectChanger => _effectChanger;

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        private void OnMouseDown()
        {
            if (_shopScreen.IsOpen && _shopScreen != null)
                return;

            foreach (Level level in _allLevels)
                level.GetComponent<EffectChanger>().StopParticles();

            _effectChanger.ActivationEffects();
            _effectChanger.SelectedEffectPlay();
            _cameraDistance.AssignMovementTarget(transform);

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
                    _effectChanger.ColorChanger(_notOpenColor);
                    break;
                case LevelState.Unlocked:
                    _levelCubeJumping.enabled = true;
                    _effectChanger.ColorChanger(_notPassedColor);
                    break;
                case LevelState.Completed:
                    _effectChanger.ColorChanger(_passedColor);
                    break;
            }
        }

        public void Activation()
        {
            _boxCollider.enabled = true;
        }

        public void Deactivation()
        {
            _boxCollider.enabled = false;
        }
    }
}
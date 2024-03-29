using CameraFiles;
using Enum;
using UI.Screens;
using UI.Screens.LevelInfo;
using UnityEngine;

namespace Levels
{
    public class Level : MonoBehaviour
    {
        [Header("Particles")] [SerializeField] private ParticleSystem _dontSelectedCircle;
        [SerializeField] private ParticleSystem _selectedCircle;
        [SerializeField] private ParticleSystem[] _effectsSelect;
        [SerializeField] private ParticleSystem[] _line;
        [SerializeField] private ParticleSystem[] _lineMove;
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
        private Color _currentColor;

        public Level[] Nextlevel => _nextLevel;

        public int Index => _index;

        private void OnMouseDown()
        {
            if (_shopScreen.IsOpen)
                return;

            foreach (Level level in _allLevels)
                level.StopParticles();

            foreach (ParticleSystem effect in _effectsSelect)
                effect.Play();

            _selectedCircle.Play();
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
                    ColorChanger(_notOpenColor);
                    break;
                case LevelState.Unlocked:
                    _levelCubeJumping.enabled = true;
                    ColorChanger(_notPassedColor);
                    break;
                case LevelState.Completed:
                    ColorChanger(_passedColor);
                    break;
            }
        }

        public void StopParticles()
        {
            _selectedCircle.Stop();

            for (int i = 0; i < _effectsSelect.Length; i++)
                _effectsSelect[i].Stop();
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
                        _lineMove[i].Play();
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

        private void ColorChanger(Color color)
        {
            var module = _dontSelectedCircle.main;
            var selectCircle = _selectedCircle.main;
            module.startColor = color;
            selectCircle.startColor = color;

            for (int i = 0; i < _effectsSelect.Length; i++)
            {
                var effectColor = _effectsSelect[i].main;
                effectColor.startColor = color;
            }
        }
    }
}
using Enum;
using SaveAndLoad;
using UnityEngine;

namespace Levels
{
    public class LockLevel : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private Load _load;
        [SerializeField] private Level _level;
        [SerializeField] private Color _colorUnLock;
        [SerializeField] private ParticleSystem[] _fenceEffects;

        private LevelState _levelState;
        private ParticleSystem.MainModule[] _effects;

        private void Start()
        {
            _levelState = (LevelState)_load.Get(Save.LevelStatus + _index, 0);
            _effects = new ParticleSystem.MainModule[_fenceEffects.Length];

            for (int i = 0; i < _effects.Length; i++)
                _effects[i] = _fenceEffects[i].main;

            if (_levelState == LevelState.Locked)
            {
                _level.gameObject.SetActive(false);
            }
            else
            {
                for (int i = 0; i < _effects.Length; i++)
                {
                    _effects[i].startColor = _colorUnLock;
                    _fenceEffects[i].Play();
                }

                gameObject.SetActive(false);
            }
        }
    }
}
using Enum;
using SaveAndLoad;
using UnityEngine;

namespace Levels
{
    public class LockFence : MonoBehaviour
    {
        [SerializeField] private int _index;
        [SerializeField] private Load _load;
        [SerializeField] private Color _colorUnLock;
        [SerializeField] private ParticleSystem _fenceEffect;

        private LevelState _levelState;

        private void Start()
        {
            _levelState = (LevelState) _load.Get(Save.LevelStatus + _index, 0);
            ParticleSystem.MainModule effect;
            effect = _fenceEffect.main;

            if (_levelState != LevelState.Locked)
            {
                effect.startColor = _colorUnLock;
                _fenceEffect.Play();
            }
        }
    }
}